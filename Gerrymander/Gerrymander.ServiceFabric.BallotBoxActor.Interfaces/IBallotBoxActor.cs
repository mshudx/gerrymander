using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Gerrymander.Common;

namespace Gerrymander.ServiceFabric.BallotBoxActor.Interfaces
{
    /// <summary>
    /// This interface defines the methods exposed by an actor.
    /// Clients use this interface to interact with the actor that implements it.
    /// </summary>
    public interface IBallotBoxActor : IActor
    {
        Task<string> SubmitVoteAsync(Vote vote);
        Task OpenBallotBoxAsync();
        Task CloseBallotBoxAsync();
    }
}
