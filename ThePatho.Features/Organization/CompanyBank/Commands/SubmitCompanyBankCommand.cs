using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.CompanyBank.Commands
{
    public class SubmitCompanyBankCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("company_bank_id")]
        public int? CompanyBankId { get; set; }

        [JsonPropertyName("company_code")]
        public string? CompanyCode { get; set; }

        [JsonPropertyName("bank_code")]
        public string? BankCode { get; set; }

        [JsonPropertyName("branch")]
        public string Branch { get; set; } = null!;

        [JsonPropertyName("account_no")]
        public string? AccountNo { get; set; }

        [JsonPropertyName("account_name")]
        public string? AccountName { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("is_default")]
        public bool? IsDefault { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
