using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Bank.DTO;

namespace ThePatho.Features.Global.Bank.Commands
{
    public class GetBankByCriteriaCommand : IRequest<ApiResponse<BankItemDto>>
    {
        [JsonPropertyName("filter_BankCode")]
        public string FilterBankCode { get; set; } = null!;

        [JsonPropertyName("filter_Name")]
        public string FilterName { get; set; } = null!;

        [JsonPropertyName("filter_CurrencyCode")]
        public string FilterCurrencyCode { get; set; } = null!;

        [JsonPropertyName("filter_TransferCode")]
        public string? FilterTransferCode { get; set; }

        [JsonPropertyName("filter_TransdferFee")]
        public decimal? FilterTransdferFee { get; set; }

        [JsonPropertyName("filter_BranchName")]
        public string? FilterBranchName { get; set; }

        [JsonPropertyName("filter_SwiftCode")]
        public string? FilterSwiftCode { get; set; }
    }
}
