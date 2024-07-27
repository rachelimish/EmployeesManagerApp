using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Interview
    {
        public int InterviewNumber { get; set; }
        public int InterviewerId { get; set; }
        public int CandidateId { get; set; }
        public DateTime? InterviewDate { get; set; }
        public string RoleInCompany { get; set; } = null!;
        public int? ScoreInInterview { get; set; }
    }
}
