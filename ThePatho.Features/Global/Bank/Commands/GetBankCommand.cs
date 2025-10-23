using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Bank.DTO;

namespace ThePatho.Features.Global.Bank.Commands
{
    public class GetBankCommand : IRequest<ApiResponse<BankItemDto>>
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

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}
