using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Building.DTO;

namespace ThePatho.Features.Global.Building.Commands
{
    public class GetBuildingCommand : IRequest<ApiResponse<BuildingItemDto>>
    {
        [JsonPropertyName("filter_BuildingName")]
        public string? FilterBuildingName { get; set; }

        [JsonPropertyName("filter_BuildingCode")]
        public string? FilterBuildingCode { get; set; }

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
