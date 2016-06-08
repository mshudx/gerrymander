using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerrymander.Common
{
    public class Vote
    {
        private Guid _voteId;

        public Guid VoteId
        {
            get { return _voteId; }
            private set { _voteId = value; }
        }

        private string _votingDistrict;

        public string VotingDistrict
        {
            get { return _votingDistrict; }
            set { _votingDistrict = value; }
        }

        private string _votingSite;

        public string VotingSite
        {
            get { return _votingSite; }
            set { _votingSite = value; }
        }

        private string _ballotBoxId;

        public string BallotBoxId
        {
            get { return _ballotBoxId; }
            set { _ballotBoxId = value; }
        }

        private string _party;

        public string Party
        {
            get { return _party; }
            set { _party = value; }
        }

        private string _candidate;

        public string Candidate
        {
            get { return _candidate; }
            set { _candidate = value; }
        }

        private DateTime _timeOfVoting;

        public DateTime TimeOfVoting
        {
            get { return _timeOfVoting; }
            set { _timeOfVoting = value; }
        }

        public Vote()
        {
            VoteId = Guid.NewGuid();
            TimeOfVoting = DateTime.UtcNow;
        }

        public Vote(string votingDistrict, string votingSite, string ballotBoxId, string party, string candidate) : this()
        {
            VotingDistrict = votingDistrict;
            VotingSite = votingSite;
            BallotBoxId = ballotBoxId;
            Party = party;
            Candidate = candidate;
        }
    }
}
