using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class SubmitApplicantCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; set; }

        [JsonPropertyName("blacklist_remarks")]
        public string BlacklistRemarks { get; set; }

        [JsonPropertyName("birth_place")]
        public string BirthPlace { get; set; }

        [JsonPropertyName("birth_date")]
        public DateTime BirthDate { get; set; }

        [JsonPropertyName("ormas_membership")]
        public bool OrmasMembership { get; set; }

        [JsonPropertyName("is_rehire")]
        public bool IsRehire { get; set; }

        [JsonPropertyName("hired_as_emp")]
        public bool HiredAsEmp { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
