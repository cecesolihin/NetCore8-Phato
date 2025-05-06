using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class SubmitApplicantPersonalDataCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }

        [JsonPropertyName("nationality_id")]
        public int? NationalityId { get; set; }

        [JsonPropertyName("religion_id")]
        public int? ReligionId { get; set; }

        [JsonPropertyName("marital_status")]
        public string MaritalStatus { get; set; }

        [JsonPropertyName("married_date")]
        public DateTime? MarriedDate { get; set; }

        [JsonPropertyName("nick_name")]
        public string NickName { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("mobile_phone")]
        public string MobilePhone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("blood_type")]
        public string BloodType { get; set; }

        [JsonPropertyName("height")]
        public int? Height { get; set; }

        [JsonPropertyName("weight")]
        public int? Weight { get; set; }

        [JsonPropertyName("photo")]
        public byte[] Photo { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("emergency_contact_name")]
        public string EmergencyContactName { get; set; }

        [JsonPropertyName("emergency_contact")]
        public string EmergencyContact { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
