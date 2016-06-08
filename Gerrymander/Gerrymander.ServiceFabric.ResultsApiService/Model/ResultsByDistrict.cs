using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerrymander.ServiceFabric.ResultsApiService.Model
{
    public class ResultsByDistrict
    {
        public int Votes { get; set; }
        public string DistrictName { get; set; }
        public string DistrictId { get; set; }
    }
}
