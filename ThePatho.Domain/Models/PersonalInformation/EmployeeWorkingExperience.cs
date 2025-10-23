using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeeWorkingExperience
    {
        public int EmpWorkExperienceId { get; set; }
        public int EmployeeID { get; set; }
        public DateTime StartWorking { get; set; }
        public string EmploymentTypeCode { get; set; } = null!;
        public string Organization { get; set; } = null!;
        public DateTime? EndWorking { get; set; }
        public string Company { get; set; } = null!;
        public string BusinessField { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int? CityId { get; set; } = null!;
        public string JobLevel { get; set; } = null!;
        public string JobDescription { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? ReferenceName { get; set; }
        public string? ReferencePhone { get; set; }
        public string? ReferenceEmail { get; set; }
        public string? CurrencyCode21 { get; set; }
        public string? CurrencyCode15 { get; set; }
        public double? PphA21 { get; set; }
        public double? PphA15 { get; set; }
        public string? Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ResignReason { get; set; }
    }

}

