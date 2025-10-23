using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeeCareerHistory
    {
        public string CareerHistoryNo { get; set; } = null!;
        public int EmployeeID { get; set; }
        public string? EmployeeNo { get; set; }
        public string CompanyCode { get; set; } = null!;
        public string EmploymentTypeCode { get; set; } = null!;
        public string? ChangeType { get; set; }
        public string PositionCode { get; set; } = null!;
        public int OrgStructureId { get; set; }
        public string JobLevelCode { get; set; } = null!;
        public string JobClassCode { get; set; } = null!;
        public string GradeCode { get; set; } = null!;
        public string RankCode { get; set; } = null!;
        public string CostCenterCode { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Remark { get; set; }
        public bool IsDeleted { get; set; }
        public string? WorkLocationCode { get; set; }
        public string? ResignTypeCode { get; set; }
        public string? TerminationTypeCode { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? PensionTypeCode { get; set; }
        public string? AssignmentLocation { get; set; }
        public DateTime? EffectiveDateTo { get; set; }
        public int? TaxLocationID { get; set; }
        public bool IsIncludeSalary { get; set; }
        public int EmpSalCompId { get; set; }
        public string? MutationTypeCode { get; set; }
        public bool UsePayrollData { get; set; }
        public bool? UseOldJoinDate { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? OldEmployeeId { get; set; }
        public string? Path { get; set; }
        public int? JabatanId { get; set; }
        public bool IsEligibleRehire { get; set; }
    }

}

