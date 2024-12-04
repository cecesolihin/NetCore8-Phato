using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Recruitment
{
    public class RecruitStepGroupDetail
    {
        public int RecStepGroupDetailId { get; set; } // rec_step_group_detail_id
        public string RecStepGroupCode { get; set; } // rec_step_group_code
        public string RecruitStepCode { get; set; } // recruit_step_code
        public int Order { get; set; } // order
        public int? Duration { get; set; } // duration
        public string? ProcessPass { get; set; } // process_pass
        public string? InsertedBy { get; set; } // inserted_by
        public DateTime? InsertedDate { get; set; } // inserted_date
        public string? ModifiedBy { get; set; } // modified_by
        public DateTime? ModifiedDate { get; set; } // modified_date

        // Navigation properties
        public RecruitStepGroup RecruitStepGroup { get; set; }
        public RecruitStep RecruitStep { get; set; }
    }

}
