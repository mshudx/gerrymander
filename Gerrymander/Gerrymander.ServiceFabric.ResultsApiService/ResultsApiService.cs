using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Gerrymander.ServiceFabric.VotingSite.Interfaces;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Client;

namespace Gerrymander.ServiceFabric.ResultsApiService
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance. 
    /// </summary>
    internal sealed class ResultsApiService : StatelessService
    {
        public ResultsApiService(StatelessServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (like tcp, http) for this service instance.
        /// </summary>
        /// <returns>The collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext => new OwinCommunicationListener(Startup.ConfigureApp, serviceContext, ServiceEventSource.Current, "ServiceEndpoint"))
            };
        }

        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            IVotingSite votingSiteClient = ServiceProxy.Create<IVotingSite>(
                serviceUri: new Uri("fabric:/Gerrymander.ServiceFabric/VotingSiteService"),
                partitionKey: new ServicePartitionKey(""));

            await base.RunAsync(cancellationToken);
        }
    }
}
