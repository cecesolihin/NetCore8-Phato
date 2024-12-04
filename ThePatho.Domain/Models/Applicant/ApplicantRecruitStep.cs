using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Applicant
{
    public class ApplicantRecruitStep
    {
        public int AppRecStepId { get; set; }
        public int RecApplicationId { get; set; }
        public string RecruitStepCode { get; set; }
        public string Score { get; set; }
        public string Notes { get; set; }
        public string Attachment { get; set; }
        public string Status { get; set; }
        public int? EmpScorer { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public string ReasonCode { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}
