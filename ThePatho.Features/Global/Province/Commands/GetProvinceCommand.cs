using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Province.DTO;

namespace ThePatho.Features.Global.Province.Commands
{
    public class GetProvinceCommand : IRequest<ApiResponse<ProvinceItemDto>>
    {
        [JsonPropertyName("filter_Name")]
        public string? FilterName { get; set; }


        [JsonPropertyName("filter_Country")]
        public int? FilterCountry { get; set; }

        [JsonPropertyName("filter_Abbreviation")]
        public string? FilterAbbreviation { get; set; }

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
