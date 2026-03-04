using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeFamily.Commands
{
    public class SubmitEmployeeFamilyCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employeeFamilyId")]
        public int EmployeeFamilyId { get; set; }

        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("relationCode")]
        public string RelationCode { get; set; } = null!;

        [JsonPropertyName("familyName")]
        public string FamilyName { get; set; } = null!;

        [JsonPropertyName("gender")]
        public string Gender { get; set; } = null!;

        [JsonPropertyName("birthPlace")]
        public string BirthPlace { get; set; } = null!;

        [JsonPropertyName("birthDate")]
        public string? BirthDate { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = null!;

        [JsonPropertyName("bloodTypeCode")]
        public string BloodTypeCode { get; set; } = null!;

        [JsonPropertyName("eduLevelCode")]
        public string EduLevelCode { get; set; } = null!;

        [JsonPropertyName("maritalStatusCode")]
        public string MaritalStatusCode { get; set; } = null!;

        [JsonPropertyName("dependentStatus")]
        public string DependentStatus { get; set; } = null!;

        [JsonPropertyName("emergencyContact")]
        public bool EmergencyContact { get; set; }

        [JsonPropertyName("workingStatus")]
        public bool? WorkingStatus { get; set; }

        [JsonPropertyName("vitalStatus")]
        public bool? VitalStatus { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; } = null!;

        [JsonPropertyName("position")]
        public string Position { get; set; } = null!;

        [JsonPropertyName("kkNo")]
        public string KkNo { get; set; } = null!;

        [JsonPropertyName("identityNo")]
        public string IdentityNo { get; set; } = null!;

        [JsonPropertyName("bpjsNo")]
        public string BpjsNo { get; set; } = null!;

        [JsonPropertyName("insuranceName")]
        public string InsuranceName { get; set; } = null!;

        [JsonPropertyName("polisNo")]
        public string PolisNo { get; set; } = null!;

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

