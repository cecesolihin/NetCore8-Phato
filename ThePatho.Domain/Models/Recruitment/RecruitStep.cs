using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Recruitment
{
    public class RecruitStep
    {
        public string RecruitStepCode { get; set; } // recruit_step_code
        public string? RecruitStepName { get; set; } // recruit_step_name
        public bool UseFailedReason { get; set; } // use_failed_reason
        public decimal? MinScore { get; set; } // min_score
        public string? InsertedBy { get; set; } // inserted_by
        public DateTime? InsertedDate { get; set; } // inserted_date
        public string? ModifiedBy { get; set; } // modified_by
        public DateTime? ModifiedDate { get; set; } // modified_date
    }
}
