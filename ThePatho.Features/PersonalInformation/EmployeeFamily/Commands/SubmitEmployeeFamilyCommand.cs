using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeFamily.Commands
{
    public class SubmitEmployeeFamilyCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_family_id")]
        public int EmployeeFamilyId { get; set; }

        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("relation_code")]
        public string RelationCode { get; set; } = null!;

        [JsonPropertyName("family_name")]
        public string FamilyName { get; set; } = null!;

        [JsonPropertyName("gender")]
        public string Gender { get; set; } = null!;

        [JsonPropertyName("birth_place")]
        public string BirthPlace { get; set; } = null!;

        [JsonPropertyName("birth_date")]
        public string? BirthDate { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = null!;

        [JsonPropertyName("blood_type_code")]
        public string BloodTypeCode { get; set; } = null!;

        [JsonPropertyName("edu_level_code")]
        public string EduLevelCode { get; set; } = null!;

        [JsonPropertyName("marital_status_code")]
        public string MaritalStatusCode { get; set; } = null!;

        [JsonPropertyName("dependent_status")]
        public string DependentStatus { get; set; } = null!;

        [JsonPropertyName("emergency_contact")]
        public bool EmergencyContact { get; set; }

        [JsonPropertyName("working_status")]
        public bool? WorkingStatus { get; set; }

        [JsonPropertyName("vital_status")]
        public bool? VitalStatus { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; } = null!;

        [JsonPropertyName("position")]
        public string Position { get; set; } = null!;

        [JsonPropertyName("kk_no")]
        public string KkNo { get; set; } = null!;

        [JsonPropertyName("identity_no")]
        public string IdentityNo { get; set; } = null!;

        [JsonPropertyName("bpjs_no")]
        public string BpjsNo { get; set; } = null!;

        [JsonPropertyName("insurance_name")]
        public string InsuranceName { get; set; } = null!;

        [JsonPropertyName("polis_no")]
        public string PolisNo { get; set; } = null!;

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

