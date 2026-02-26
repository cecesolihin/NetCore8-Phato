using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.CompanyBank.Commands
{
    public class SubmitCompanyBankCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("companyBankId")]
        public int? CompanyBankId { get; set; }

        [JsonPropertyName("companyCode")]
        public string? CompanyCode { get; set; }

        [JsonPropertyName("bankCode")]
        public string? BankCode { get; set; }

        [JsonPropertyName("branch")]
        public string Branch { get; set; } = null!;

        [JsonPropertyName("accountNo")]
        public string? AccountNo { get; set; }

        [JsonPropertyName("accountName")]
        public string? AccountName { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("isDefault")]
        public bool? IsDefault { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
