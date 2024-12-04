using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Recruitment
{
    public class RecruitmentReqStep
    {
        public int RecruitReqStepId { get; set; }
        public string RequestNo { get; set; }
        public string RecruitStepCode { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}
