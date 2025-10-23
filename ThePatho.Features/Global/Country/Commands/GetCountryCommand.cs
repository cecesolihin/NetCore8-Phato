using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Country.DTO;

namespace ThePatho.Features.Global.Country.Commands
{
    public class GetCountryCommand : IRequest<ApiResponse<CountryItemDto>>
    {
        [JsonPropertyName("filter_Name")]
        public string? FilterName { get; set; }

        [JsonPropertyName("filter_NumericIsoCode")]
        public int? FilterNumericIsoCode { get; set; }

        [JsonPropertyName("filter_ThreeLetterIsoCode")]
        public string? FilterThreeLetterIsoCode { get; set; }

        [JsonPropertyName("filter_TwoLetterIsoCode")]
        public string? FilterTwoLetterIsoCode { get; set; }

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
