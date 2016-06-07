using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gerrymander.ServiceFabric.VotingApi.Controllers
{
    public class VoteController : ApiController
    {
        public string Get(string value)
        {
            return "Echo: " + value;
        }

        public void Post([FromBody]string value)
        {

        }
    }
}
