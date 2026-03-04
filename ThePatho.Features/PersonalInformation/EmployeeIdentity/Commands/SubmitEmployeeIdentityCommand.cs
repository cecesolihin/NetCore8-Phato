using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands
{
    public class SubmitEmployeeIdentityCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("identityCode")]
        public string IdentityCode { get; set; } = null!;

        [JsonPropertyName("companyCode")]
        public string CompanyCode { get; set; } = null!;

        [JsonPropertyName("identityNo")]
        public string IdentityNo { get; set; } = null!;

        [JsonPropertyName("issuedDate")]
        public string? IssuedDate { get; set; }

        [JsonPropertyName("expiredDate")]
        public string? ExpiredDate { get; set; }

        [JsonPropertyName("fileUpload")]
        public string? FileUpload { get; set; }

        [JsonPropertyName("fileName")]
        public string? FileName { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

