using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands
{
    public class SubmitEmployeeIdentityCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("identity_code")]
        public string IdentityCode { get; set; } = null!;

        [JsonPropertyName("company_code")]
        public string CompanyCode { get; set; } = null!;

        [JsonPropertyName("identity_no")]
        public string IdentityNo { get; set; } = null!;

        [JsonPropertyName("issued_date")]
        public string? IssuedDate { get; set; }

        [JsonPropertyName("expired_date")]
        public string? ExpiredDate { get; set; }

        [JsonPropertyName("file_upload")]
        public byte[]? FileUpload { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; } = null!;

        [JsonPropertyName("file_full_path")]
        public string FileFullPath { get; set; } = null!;

        [JsonPropertyName("file_name")]
        public string FileName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

