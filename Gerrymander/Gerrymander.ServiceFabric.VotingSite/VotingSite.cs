using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gerrymander.Common;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Data;
using Gerrymander.ServiceFabric.VotingSite.Interfaces;
using Gerrymander.ServiceFabric.VotingSite.Context;

namespace Gerrymander.ServiceFabric.VotingSite
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class VotingSite : StatefulService, IVotingSite
    {
        private CancellationToken cancellationToken;
        private const string votesName = "storedVotes";

        public VotingSite(StatefulServiceContext context)
            : base(context)
        {
        }

        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            this.cancellationToken = cancellationToken;

            var votes = await this.StateManager.GetOrAddAsync<IReliableQueue<Vote>>(votesName);
            while(!cancellationToken.IsCancellationRequested)
            {
                using (var transaction = StateManager.CreateTransaction())
                {
                    var vote = await votes.TryDequeueAsync(transaction, TimeSpan.FromMinutes(1), cancellationToken);
                    if(vote.HasValue)
                    {
                        using (var db = new gerrymanderEntities())
                        {
                            var candidate = db.Candidates.SingleOrDefault(c => c.Name == vote.Value.Candidate);
                            if(candidate != null)
                            {
                                candidate.VoteCount = candidate.VoteCount + 1;
                            }
                            await db.SaveChangesAsync();
                        }
                    }
                    await transaction.CommitAsync();
                }
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }
        }

        /// <summary>
        /// Optional override to create listeners (e.g., HTTP, Service Remoting, WCF, etc.) for this service replica to handle client or user requests.
        /// </summary>
        /// <remarks>
        /// For more information on service communication, see http://aka.ms/servicefabricservicecommunication
        /// </remarks>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new[] { new ServiceReplicaListener(context => this.CreateServiceRemotingListener(context)) };
        }

        /// <summary>
        /// This method can be called remotely via Service Remoting.
        /// </summary>
        /// <param name="vote"></param>
        /// <returns></returns>
        public async Task StoreVoteAsync(Vote vote)
        {
            var votes = await StateManager.GetOrAddAsync<IReliableQueue<Vote>>(votesName);

            using (var transaction = StateManager.CreateTransaction())
            {
                await votes.EnqueueAsync(transaction, vote);
                await transaction.CommitAsync();

            }
        }
    }
}
