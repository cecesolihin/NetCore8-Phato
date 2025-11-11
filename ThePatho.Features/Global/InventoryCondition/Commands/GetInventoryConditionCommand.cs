using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryCondition.DTO;

namespace ThePatho.Features.Global.InventoryCondition.Commands
{
    public class GetInventoryConditionCommand : IRequest<ApiResponse<InventoryConditionItemDto>>
    {
        [JsonPropertyName("filter_InventoryConditionName")]
        public string? FilterInventoryConditionName { get; set; }

        [JsonPropertyName("filter_InventoryConditionCode")]
        public string? FilterInventoryConditionCode { get; set; }

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





