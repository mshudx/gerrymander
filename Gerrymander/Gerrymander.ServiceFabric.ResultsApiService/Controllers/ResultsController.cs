using Gerrymander.ServiceFabric.ResultsApiService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gerrymander.ServiceFabric.ResultsApiService.Controllers
{
    public class ResultsController : ApiController
    {
        // GET api/values 
        public async Task<Results> Get()
        {
            var result = new Results() { Votes = 1 };
            return result;
        }

        public async Task<IEnumerable<ResultsByCandidate>> GetByCandidates()
        {
            var result = new[]
            {
                new ResultsByCandidate() { Votes = 1, CandidateId = "", CandidateName = "" },
            };
            return result;
        }
        // GET api/values/5 
        public async Task<ResultsByCandidate> GetByCandidate(string id)
        {
            var result = new ResultsByCandidate() { Votes = 1, CandidateId = "", CandidateName = "" };
            return result;
        }

        public async Task<IEnumerable<ResultsByDistrict>> GetByDistricts()
        {
            var result = new[]
            {
                new ResultsByDistrict() { Votes = 1, DistrictId = "", DistrictName = "" },
            };
            return result;
        }

        public async Task<ResultsByDistrict> GetByDistrict(string id)
        {
            var result = new ResultsByDistrict() { Votes = 1, DistrictId = "", DistrictName = "" };
            return result;
        }

        public async Task<IEnumerable<ResultsBySite>> GetBySites()
        {
            var result = new[]
            {
                new ResultsBySite() { Votes = 1, SiteId = "", SiteName = "" },
            };
            return result;
        }

        public async Task<ResultsBySite> GetBySite(string id)
        {
            var result = new ResultsBySite() { Votes = 1, SiteId = "", SiteName = "" };
            return result;
        }

        public async Task<IEnumerable<ResultsByParty>> GetByParties()
        {
            var result = new[]
{
                new ResultsByParty() { Votes = 1, PartyId = "", PartyName = "" },
            };
            return result;
        }

        public async Task<ResultsByParty> GetByParty(string id)
        {
            var result = new ResultsByParty() { Votes = 1, PartyId = "", PartyName = "" };
            return result;
        }
    }
}
