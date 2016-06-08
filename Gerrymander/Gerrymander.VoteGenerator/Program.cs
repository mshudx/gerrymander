using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerrymander.Common;
using System.Net.Http;
using Newtonsoft.Json;

namespace Gerrymander.VoteGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //SubmitManualVote();
            SubmitRandomVotes(1);
            Console.ReadLine();
        }

        private static void SubmitRandomVotes(int voteCount)
        {
            var votingDistricts = GetVotingDistricts();
            for(var currentVote = 0; currentVote < voteCount; currentVote++)
            {
                // Select a random voting district
                Random random = new Random();
                int currentDistrictId = random.Next(votingDistricts.Count);
                var votingDistrict = votingDistricts[currentDistrictId];

                // Select a random voting site in the voting district
                var votingSites = GetVotingSitesByVotingDistrict(votingDistrict.Id);
                int currentSiteId = random.Next(votingSites.Count);
                var votingSite = votingSites[currentSiteId];

                // Select a random candidate in the voting district
                var candidates = GetCandidatesByVotingDistrict(votingDistrict.Id);
                int currentCandidateId = random.Next(candidates.Count);
                var candidate = candidates[currentCandidateId];

                // Get the party the candidate belongs to
                var party = GetPartyByCandidate(candidate.Id);

                // Submit the vote
                SubmitVote(votingDistrict.Name, votingSite.Name, "(test ballot box)", party.Name, candidate.Name);

                Console.WriteLine("Vote submitted for {0}, {1}, {2}, {3}, {4}", votingDistrict.Name, votingSite.Name, "(test ballot box)", party.Name, candidate.Name);
            }
        }

        private static void SubmitManualVote()
        {
            Console.WriteLine("Voting District:");
            var votingDistrict = Console.ReadLine();
            Console.WriteLine("Voting Site:");
            var votingSite = Console.ReadLine();
            Console.WriteLine("Voting Ballot Box:");
            var ballotBoxId = Console.ReadLine();
            Console.WriteLine("Party:");
            var party = Console.ReadLine();
            Console.WriteLine("Candidate:");
            var candidate = Console.ReadLine();
            SubmitVote(votingDistrict, votingSite, ballotBoxId, party, candidate);
            Console.WriteLine("Vote submitted.");
            Console.ReadLine();
        }

        private static async void SubmitVote(string votingDistrict, string votingSite, string ballotBoxId, string party, string candidate)
        {
            Vote vote = new Vote(votingDistrict, votingSite, ballotBoxId, party, candidate);
            HttpClient client = new HttpClient();
            var uri = "http://gerrymander.westeurope.cloudapp.azure.com/api/vote";
            var serializedVote = JsonConvert.SerializeObject(vote);
            HttpContent content = new StringContent(serializedVote, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(uri, content);
            client.Dispose();
        }

        private static List<VotingDistrict> GetVotingDistricts()
        {
            gerrymanderEntities db = new gerrymanderEntities();
            return db.VotingDistricts.ToList();
        }

        private static List<VotingSite> GetVotingSitesByVotingDistrict(int votingDistrictId)
        {
            gerrymanderEntities db = new gerrymanderEntities();
            return db.VotingSites.Where(s => s.VotingDistrict == votingDistrictId).ToList();
        }

        private static List<Candidate> GetCandidatesByVotingDistrict(int votingDistrictId)
        {
            gerrymanderEntities db = new gerrymanderEntities();
            return db.Candidates.Where(d => d.VotingDistrict == votingDistrictId).ToList();
        }

        private static Party GetPartyByCandidate(int candidateId)
        {
            gerrymanderEntities db = new gerrymanderEntities();
            var candidate = db.Candidates.First(c => c.Id == candidateId);
            
            return null;
        }
    }
}
