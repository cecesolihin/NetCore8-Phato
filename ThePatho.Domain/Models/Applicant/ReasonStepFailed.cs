using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Applicant
{
    public class ReasonStepFailed
    {
        public string RecruitStepCode { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonName { get; set; }
        public bool Order { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}
