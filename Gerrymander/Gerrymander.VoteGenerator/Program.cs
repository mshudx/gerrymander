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
            SubmitManualVote();
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
        }
    }
}
