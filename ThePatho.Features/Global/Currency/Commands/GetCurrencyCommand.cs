using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Currency.DTO;

namespace ThePatho.Features.Global.Currency.Commands
{
    public class GetCurrencyCommand : IRequest<ApiResponse<CurrencyItemDto>>
    {
        
        [JsonPropertyName("filter_CurrencyCode")]
        public string? FilterCurrencyCode { get; set; }

        [JsonPropertyName("filter_CurrencyName")]
        public string? FilterCurrencyName { get; set; }

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


