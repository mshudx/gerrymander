using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerrymander.ServiceFabric.ResultsApiService.Model
{
    public class ResultsBySite
    {
        public int Votes { get; set; }
        public string SiteName { get; set; }
        public string SiteId { get; set; }
    }
}
