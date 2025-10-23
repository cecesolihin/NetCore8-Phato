using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Bank.Commands
{
    public class SubmitBankCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("bank_code")]
        public string BankCode { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; } = null!;

        [JsonPropertyName("transfer_code")]
        public string? TransferCode { get; set; }

        [JsonPropertyName("transfer_fee")]
        public decimal? TransdferFee { get; set; }

        [JsonPropertyName("branch_name")]
        public string? BranchName { get; set; }

        [JsonPropertyName("swift_code")]
        public string? SwiftCode { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
