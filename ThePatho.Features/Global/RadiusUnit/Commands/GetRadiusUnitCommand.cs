using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RadiusUnit.DTO;

namespace ThePatho.Features.Global.RadiusUnit.Commands
{
    public class GetRadiusUnitCommand : IRequest<ApiResponse<RadiusUnitItemDto>>
    {
        [JsonPropertyName("filter_RadiusUnitCode")]
        public string? FilterRadiusUnitCode { get; set; }

        [JsonPropertyName("filter_RadiusUnitName")]
        public string? FilterRadiusUnitName { get; set; }

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
