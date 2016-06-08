using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Actors.Client;
using Gerrymander.ServiceFabric.BallotBoxActor.Interfaces;
using Gerrymander.Common;

namespace Gerrymander.ServiceFabric.BallotBoxActor
{
    /// <remarks>
    /// This class represents an actor.
    /// Every ActorID maps to an instance of this class.
    /// The StatePersistence attribute determines persistence and replication of actor state:
    ///  - Persisted: State is written to disk and replicated.
    ///  - Volatile: State is kept in memory only and replicated.
    ///  - None: State is kept in memory only and not replicated.
    /// </remarks>
    [StatePersistence(StatePersistence.Persisted)]
    internal class BallotBoxActor : Actor, IBallotBoxActor
    {
        /// <summary>
        /// This method is called whenever an actor is activated.
        /// An actor is activated the first time any of its methods are invoked.
        /// </summary>
        protected override Task OnActivateAsync()
        {
            ActorEventSource.Current.ActorMessage(this, "Actor activated.");
            return Task.Delay(0); // causes no delay and suppresses the compiler warning
        }

        #region Open/Close Ballot Box
        private const string isOpenStateName = "isOpen";

        public async Task OpenBallotBoxAsync()
        {
            await ChangeIsOpenTo(true);
        }

        public async Task CloseBallotBoxAsync()
        {
            await ChangeIsOpenTo(false);
        }

        private async Task ChangeIsOpenTo(bool value)
        {
            if (await this.StateManager.ContainsStateAsync(isOpenStateName))
            {
                await this.StateManager.RemoveStateAsync(isOpenStateName);
            }
            await this.StateManager.AddStateAsync(isOpenStateName, value);
        }
        #endregion

        #region Submit Vote
        public async Task<string> SubmitVoteAsync(Vote vote)
        {
            var validationResult = await ValidateVoteAsync(vote);
            if (validationResult != null) // there was a problem
            {
                return validationResult;
            }
            else
            {
                return null;
                // TODO forward to Voting Site SFS
            }
        }

        private async Task<string> ValidateVoteAsync(Vote vote)
        {
            if (await this.StateManager.ContainsStateAsync(isOpenStateName) == false ||
                await this.StateManager.GetStateAsync<bool>(isOpenStateName) == false)
            {
                return "Vote validation error: ballot box is not open";
            }
            else if (vote.TimeOfVoting >= DateTime.Now)
            {
                return "Vote validation error: timestamp is in the future";
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
