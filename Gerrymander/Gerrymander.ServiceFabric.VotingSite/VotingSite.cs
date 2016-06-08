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

namespace Gerrymander.ServiceFabric.VotingSite
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class VotingSite : StatefulService, IVotingSite
    {
        private const string storedVotesDictionaryName = "storedVotes";
        private IReliableDictionary<string, Vote> storedVotes;

        public VotingSite(StatefulServiceContext context)
            : base(context)
        { }

        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            storedVotes = await this.StateManager.GetOrAddAsync<IReliableDictionary<string, Vote>>(storedVotesDictionaryName);
            await base.RunAsync(cancellationToken);
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
        public async Task StoreVote(Vote vote)
        {
            var transaction = this.StateManager.CreateTransaction();
            await storedVotes.AddOrUpdateAsync(
                transaction,
                vote.VoteId.ToString(),
                vote,
                (_, __) => { return vote; });
            await transaction.CommitAsync();
        }
    }
}
