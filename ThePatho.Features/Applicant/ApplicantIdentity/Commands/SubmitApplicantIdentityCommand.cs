using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class SubmitApplicantIdentityCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }

        [JsonPropertyName("identity_code")]
        public string IdentityCode { get; set; }

        [JsonPropertyName("identity_no")]
        public string IdentityNo { get; set; }

        [JsonPropertyName("issued_date")]
        public DateTime? IssuedDate { get; set; }

        [JsonPropertyName("expired_date")]
        public DateTime? ExpiredDate { get; set; }

        [JsonPropertyName("file_full_path")]
        public string FileFullPath { get; set; }

        [JsonPropertyName("file_name")]
        public string FileName { get; set; }

        [JsonPropertyName("remark")]
        public string Remark { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
