using Gerrymander.Common;
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerrymander.ServiceFabric.VotingSite.Interfaces
{
    public interface IVotingSite : IService
    {
        Task StoreVoteAsync(Vote vote);
        Task<List<Vote>> GetAllStoredVotes();
    }
}
