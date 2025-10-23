using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroup.DTO;

namespace ThePatho.Features.Global.InventoryGroup.Commands
{
    public class GetInventoryGroupCommand : IRequest<ApiResponse<InventoryGroupItemDto>>
    {
        [JsonPropertyName("filter_InventoryGroupCode")]
        public string? FilterInventoryGroupCode { get; set; }

        [JsonPropertyName("filter_InventoryGroupName")]
        public string? FilterInventoryGroupName { get; set; }

        [JsonPropertyName("filter_GroupBy")]
        public string? FilterGroupBy { get; set; }

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

