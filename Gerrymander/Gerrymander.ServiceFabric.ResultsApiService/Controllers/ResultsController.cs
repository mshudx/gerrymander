﻿using Gerrymander.ServiceFabric.ResultsApiService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gerrymander.ServiceFabric.ResultsApiService.Controllers
{
    [RoutePrefix("api/results")]
    public class ResultsController : ApiController
    {
        [Route("")]
        [HttpGet]
        public async Task<Results> Get()
        {
            var result = new Results() { Votes = 1 };
            return result;
        }

        [Route("candidates")]
        [HttpGet]
        public async Task<IEnumerable<ResultsByCandidate>> GetByCandidates()
        {
            var result = new[]
            {
                new ResultsByCandidate() { Votes = 1, CandidateId = "", CandidateName = "" },
            };
            return result;
        }

        [Route("candidates/{id:int}")]
        [HttpGet]
        public async Task<ResultsByCandidate> GetByCandidate(string id)
        {
            var result = new ResultsByCandidate() { Votes = 1, CandidateId = "", CandidateName = "" };
            return result;
        }

        [Route("districts")]
        [HttpGet]
        public async Task<IEnumerable<ResultsByDistrict>> GetByDistricts()
        {
            var result = new[]
            {
                new ResultsByDistrict() { Votes = 1, DistrictId = "", DistrictName = "" },
            };
            return result;
        }

        [Route("districts/{id:int}")]
        [HttpGet]
        public async Task<ResultsByDistrict> GetByDistrict(string id)
        {
            var result = new ResultsByDistrict() { Votes = 1, DistrictId = "", DistrictName = "" };
            return result;
        }

        [Route("sites")]
        [HttpGet]
        public async Task<IEnumerable<ResultsBySite>> GetBySites()
        {
            var result = new[]
            {
                new ResultsBySite() { Votes = 1, SiteId = "", SiteName = "" },
            };
            return result;
        }

        [Route("sites/{id:int}")]
        [HttpGet]
        public async Task<ResultsBySite> GetBySite(string id)
        {
            var result = new ResultsBySite() { Votes = 1, SiteId = "", SiteName = "" };
            return result;
        }

        [Route("parties")]
        [HttpGet]
        public async Task<IEnumerable<ResultsByParty>> GetByParties()
        {
            var result = new[]
{
                new ResultsByParty() { Votes = 1, PartyId = "", PartyName = "" },
            };
            return result;
        }

        [Route("parties/{id:int}")]
        [HttpGet]
        public async Task<ResultsByParty> GetByParty(string id)
        {
            var result = new ResultsByParty() { Votes = 1, PartyId = "", PartyName = "" };
            return result;
        }
    }
}
