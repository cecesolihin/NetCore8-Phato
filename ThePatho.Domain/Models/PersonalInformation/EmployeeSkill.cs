using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeeSkill
    {
        public int EmployeeID { get; set; }
        public string SkillCode { get; set; } = null!;
        public string ProfiencyCode { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? TakenDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string? Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}

