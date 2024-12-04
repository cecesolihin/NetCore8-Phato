using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Applicant
{
    public class ApplicantSkill
    {
        public string ApplicantNo { get; set; }
        public string SkillCode { get; set; }
        public string Description { get; set; }
        public string ProficiencyCode { get; set; }
        public DateTime? TakenDate { get; set; }
        public DateTime? ExpDate { get; set; }
        public string Remarks { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}
