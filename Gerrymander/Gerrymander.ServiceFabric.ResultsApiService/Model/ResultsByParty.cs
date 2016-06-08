using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerrymander.ServiceFabric.ResultsApiService.Model
{
    public class ResultsByParty
    {
        public int Votes { get; set; }
        public string PartyName { get; set; }
        public string PartyId { get; set; }
    }
}
