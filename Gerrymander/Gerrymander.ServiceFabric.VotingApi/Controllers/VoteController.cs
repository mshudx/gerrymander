using Gerrymander.Common;
using Gerrymander.ServiceFabric.BallotBoxActor.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gerrymander.ServiceFabric.VotingApi.Controllers
{
    public class VoteController : ApiController
    {
        public string Get()
        {
            return "Voting API is online (" + DateTime.Now.ToString() + "). Use HTTP POST to send a vote.";
        }

        public async Task<HttpResponseMessage> Post([FromBody]Vote vote)
        {
            // Received vote; redirecting it to the appropriate ballot box actor
            ActorId actorId = new ActorId(vote.BallotBoxId);
            IBallotBoxActor ballotBoxActor =
                ActorProxy.Create<IBallotBoxActor>(
                    actorId,
                    new Uri("fabric:/Gerrymander.ServiceFabric/BallotBoxActorService"));

            // TODO open ballot boxes when the election is opened
            await ballotBoxActor.OpenBallotBoxAsync();
            var voteResult = await ballotBoxActor.SubmitVoteAsync(vote);
            if (voteResult == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, voteResult);
            }
        }
    }
}
