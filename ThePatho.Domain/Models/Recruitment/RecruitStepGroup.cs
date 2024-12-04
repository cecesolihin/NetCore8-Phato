using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Recruitment
{
    public class RecruitStepGroup
    {
        public string RecStepGroupCode { get; set; } // rec_step_group_code
        public string? RecStepGroupName { get; set; } // rec_step_group_name
        public string? InsertedBy { get; set; } // inserted_by
        public DateTime? InsertedDate { get; set; } // inserted_date
        public string? ModifiedBy { get; set; } // modified_by
        public DateTime? ModifiedDate { get; set; } // modified_date

        // Navigation property
        public ICollection<RecruitStepGroupDetail> RecruitStepGroupDetails { get; set; }
    }

}
