using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands
{
    public class SubmitEmployeeCareerHistoryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("careerHistoryNo")]
        public string CareerHistoryNo { get; set; } = null!;

        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("employeeNo")]
        public string? EmployeeNo { get; set; }

        [JsonPropertyName("companyCode")]
        public string CompanyCode { get; set; } = null!;

        [JsonPropertyName("employmentTypeCode")]
        public string EmploymentTypeCode { get; set; } = null!;

        [JsonPropertyName("changeType")]
        public string? ChangeType { get; set; }

        [JsonPropertyName("positionCode")]
        public string PositionCode { get; set; } = null!;

        [JsonPropertyName("orgStructureId")]
        public int OrgStructureId { get; set; }

        [JsonPropertyName("jobLevelCode")]
        public string JobLevelCode { get; set; } = null!;

        [JsonPropertyName("jobClassCode")]
        public string JobClassCode { get; set; } = null!;

        [JsonPropertyName("gradeCode")]
        public string GradeCode { get; set; } = null!;

        [JsonPropertyName("rankCode")]
        public string RankCode { get; set; } = null!;

        [JsonPropertyName("costCenterCode")]
        public string CostCenterCode { get; set; } = null!;

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; } = null!;

        [JsonPropertyName("endDate")]
        public string? EndDate { get; set; }

        [JsonPropertyName("remark")]
        public string? Remark { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("workLocationCode")]
        public string? WorkLocationCode { get; set; }

        [JsonPropertyName("resignTypeCode")]
        public string? ResignTypeCode { get; set; }

        [JsonPropertyName("terminationTypeCode")]
        public string? TerminationTypeCode { get; set; }

        [JsonPropertyName("pensionTypeCode")]
        public string? PensionTypeCode { get; set; }

        [JsonPropertyName("assignmentLocation")]
        public string? AssignmentLocation { get; set; }

        [JsonPropertyName("effectiveDateTo")]
        public string? EffectiveDateTo { get; set; }

        [JsonPropertyName("taxLocationId")]
        public int? TaxLocationId { get; set; }

        [JsonPropertyName("isIncludeSalary")]
        public bool IsIncludeSalary { get; set; }

        [JsonPropertyName("empSalCompId")]
        public int EmpSalCompId { get; set; }

        [JsonPropertyName("mutationTypeCode")]
        public string? MutationTypeCode { get; set; }

        [JsonPropertyName("usePayrollData")]
        public bool UsePayrollData { get; set; }

        [JsonPropertyName("useOldJoinDate")]
        public bool? UseOldJoinDate { get; set; }

        [JsonPropertyName("joinDate")]
        public string? JoinDate { get; set; }

        [JsonPropertyName("oldEmployeeId")]
        public int? OldEmployeeId { get; set; }

        [JsonPropertyName("path")]
        public string? Path { get; set; }

        [JsonPropertyName("jabatanId")]
        public int? JabatanId { get; set; }

        [JsonPropertyName("isEligibleRehire")]
        public bool IsEligibleRehire { get; set; }

        [JsonPropertyName("insertedBy")]
        public string? InsertedBy { get; set; }

        [JsonPropertyName("insertedDate")]
        public string? InsertedDate { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("modifiedDate")]
        public string? ModifiedDate { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

