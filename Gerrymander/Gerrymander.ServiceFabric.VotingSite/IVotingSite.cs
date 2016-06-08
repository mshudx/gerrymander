using Gerrymander.Common;
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerrymander.ServiceFabric.VotingSite
{
    public interface IVotingSite : IService
    {
        Task StoreVote(Vote vote);
        Task<List<Vote>> GetAllStoredVotes();
    }
}
