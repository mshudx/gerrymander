using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerrymander.Common
{
    public class ElectionData
    {
        private List<Party> _parties;

        public List<Party> Parties
        {
            get { return _parties; }
            set { _parties = value; }
        }

        private List<VotingDistrict> _votingDistricts;

        public List<VotingDistrict> VotingDistricts
        {
            get { return _votingDistricts; }
            set { _votingDistricts = value; }
        }

        public ElectionData() { }

        public ElectionData(List<Party> parties, List<VotingDistrict> votingDistricts)
        {
            Parties = parties;
            VotingDistricts = votingDistricts;
        }
    }

    public class Party
    {
        private string _partyName;

        public string PartyName
        {
            get { return _partyName; }
            set { _partyName = value; }
        }

        private List<Candidate> _candidates;

        public List<Candidate> Candidates
        {
            get { return _candidates; }
            set { _candidates = value; }
        }

    }

    public class Candidate
    {
        private string _candidateName;

        public string CandidateName
        {
            get { return _candidateName; }
            set { _candidateName = value; }
        }

        private string _votingDistrict;

        public string VotingDistrict
        {
            get { return _votingDistrict; }
            set { _votingDistrict = value; }
        }

    }

    public class VotingDistrict
    {
        private string _votingDistrictName;

        public string VotingDistrictName
        {
            get { return _votingDistrictName; }
            set { _votingDistrictName = value; }
        }

        private List<VotingSite> _votingSites;

        public List<VotingSite> VotingSites
        {
            get { return _votingSites; }
            set { _votingSites = value; }
        }

    }

    public class VotingSite
    {
        private string _votingSiteName;

        public string VotingSiteName
        {
            get { return _votingSiteName; }
            set { _votingSiteName = value; }
        }

        private List<BallotBox> _ballotBoxes;

        public List<BallotBox> BallotBoxes
        {
            get { return _ballotBoxes; }
            set { _ballotBoxes = value; }
        }

    }

    public class BallotBox
    {
        private string _ballotBoxId;

        public string BallotBoxId
        {
            get { return _ballotBoxId; }
            set { _ballotBoxId = value; }
        }
    }
}
