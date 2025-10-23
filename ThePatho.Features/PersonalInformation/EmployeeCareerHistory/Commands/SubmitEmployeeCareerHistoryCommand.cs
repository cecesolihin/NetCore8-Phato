using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands
{
    public class SubmitEmployeeCareerHistoryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("career_history_no")]
        public string CareerHistoryNo { get; set; } = null!;

        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("employee_no")]
        public string? EmployeeNo { get; set; }

        [JsonPropertyName("company_code")]
        public string CompanyCode { get; set; } = null!;

        [JsonPropertyName("employment_type_code")]
        public string EmploymentTypeCode { get; set; } = null!;

        [JsonPropertyName("change_type")]
        public string? ChangeType { get; set; }

        [JsonPropertyName("position_code")]
        public string PositionCode { get; set; } = null!;

        [JsonPropertyName("org_structure_id")]
        public int OrgStructureId { get; set; }

        [JsonPropertyName("job_level_code")]
        public string JobLevelCode { get; set; } = null!;

        [JsonPropertyName("job_class_code")]
        public string JobClassCode { get; set; } = null!;

        [JsonPropertyName("grade_code")]
        public string GradeCode { get; set; } = null!;

        [JsonPropertyName("rank_code")]
        public string RankCode { get; set; } = null!;

        [JsonPropertyName("cost_center_code")]
        public string CostCenterCode { get; set; } = null!;

        [JsonPropertyName("start_date")]
        public string StartDate { get; set; } = null!;

        [JsonPropertyName("end_date")]
        public string? EndDate { get; set; }

        [JsonPropertyName("remark")]
        public string? Remark { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("work_location_code")]
        public string? WorkLocationCode { get; set; }

        [JsonPropertyName("resign_type_code")]
        public string? ResignTypeCode { get; set; }

        [JsonPropertyName("termination_type_code")]
        public string? TerminationTypeCode { get; set; }

        [JsonPropertyName("pension_type_code")]
        public string? PensionTypeCode { get; set; }

        [JsonPropertyName("assignment_location")]
        public string? AssignmentLocation { get; set; }

        [JsonPropertyName("effective_date_to")]
        public string? EffectiveDateTo { get; set; }

        [JsonPropertyName("tax_location_id")]
        public int? TaxLocationId { get; set; }

        [JsonPropertyName("is_include_salary")]
        public bool IsIncludeSalary { get; set; }

        [JsonPropertyName("emp_sal_comp_id")]
        public int EmpSalCompId { get; set; }

        [JsonPropertyName("mutation_type_code")]
        public string? MutationTypeCode { get; set; }

        [JsonPropertyName("use_payroll_data")]
        public bool UsePayrollData { get; set; }

        [JsonPropertyName("use_old_join_date")]
        public bool? UseOldJoinDate { get; set; }

        [JsonPropertyName("join_date")]
        public string? JoinDate { get; set; }

        [JsonPropertyName("old_employee_id")]
        public int? OldEmployeeId { get; set; }

        [JsonPropertyName("path")]
        public string? Path { get; set; }

        [JsonPropertyName("jabatan_id")]
        public int? JabatanId { get; set; }

        [JsonPropertyName("is_eligible_rehire")]
        public bool IsEligibleRehire { get; set; }

        [JsonPropertyName("inserted_by")]
        public string? InsertedBy { get; set; }

        [JsonPropertyName("inserted_date")]
        public string? InsertedDate { get; set; }

        [JsonPropertyName("modified_by")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("modified_date")]
        public string? ModifiedDate { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

