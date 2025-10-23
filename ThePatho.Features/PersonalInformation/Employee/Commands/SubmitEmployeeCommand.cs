using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.Employee.Commands
{
    public class SubmitEmployeeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("employee_no")]
        public string? EmployeeNo { get; set; }

        [JsonPropertyName("company_code")]
        public string CompanyCode { get; set; } = null!;

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; } = null!;

        [JsonPropertyName("middle_name")]
        public string? MiddleName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("fullname")]
        public string Fullname { get; set; } = null!;

        [JsonPropertyName("position_code")]
        public string PositionCode { get; set; } = null!;

        [JsonPropertyName("gender")]
        public string Gender { get; set; } = null!;

        [JsonPropertyName("birth_place")]
        public string? BirthPlace { get; set; }

        [JsonPropertyName("birth_date")]
        public string BirthDate { get; set; } = null!;

        [JsonPropertyName("join_date")]
        public string JoinDate { get; set; } = null!;

        [JsonPropertyName("terminate_date")]
        public string? TerminateDate { get; set; }

        [JsonPropertyName("permanent_date")]
        public string? PermanentDate { get; set; }

        [JsonPropertyName("pension_date")]
        public string? PensionDate { get; set; }

        [JsonPropertyName("job_class_code")]
        public string JobClassCode { get; set; } = null!;

        [JsonPropertyName("employment_type_code")]
        public string EmploymentTypeCode { get; set; } = null!;

        [JsonPropertyName("cost_center_code")]
        public string CostCenterCode { get; set; } = null!;

        [JsonPropertyName("tax_type")]
        public string TaxType { get; set; } = null!;

        [JsonPropertyName("tax_status_code")]
        public string TaxStatusCode { get; set; } = null!;

        [JsonPropertyName("npwp")]
        public string? Npwp { get; set; }

        [JsonPropertyName("attendance_id")]
        public string? AttendanceId { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("work_location_code")]
        public string? WorkLocationCode { get; set; }

        [JsonPropertyName("inserted_by")]
        public string? InsertedBy { get; set; }

        [JsonPropertyName("inserted_date")]
        public string? InsertedDate { get; set; }

        [JsonPropertyName("modified_by")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("modified_date")]
        public string? ModifiedDate { get; set; }

        [JsonPropertyName("tax_location_id")]
        public int? TaxLocationId { get; set; }

        [JsonPropertyName("need_replacement")]
        public bool NeedReplacement { get; set; }

        [JsonPropertyName("bpjstk_location")]
        public string? BpjstkLocation { get; set; }

        [JsonPropertyName("bpjskes_location")]
        public string? BpjskesLocation { get; set; }

        [JsonPropertyName("cap_color_id")]
        public byte? CapColorId { get; set; }

        [JsonPropertyName("pick_up_id")]
        public byte? PickUpId { get; set; }

        [JsonPropertyName("contract_end_date")]
        public string? ContractEndDate { get; set; }

        [JsonPropertyName("jabatan_id")]
        public int? JabatanId { get; set; }

        [JsonPropertyName("is_eligible_rehire")]
        public bool IsEligibleRehire { get; set; }

        [JsonPropertyName("faskes_id")]
        public int? FaskesId { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

