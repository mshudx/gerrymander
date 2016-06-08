using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerrymander.ServiceFabric.ResultsApiService.Model
{
    public class ResultsByCandidate
    {
        public int Votes { get; set; }
        public string CandidateName { get; set; }
        public string CandidateId { get; set; }
    }
}
