using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupDetail.DTO;

namespace ThePatho.Features.Global.InventoryGroupDetail.Commands
{
    public class GetInventoryGroupDetailCommand : IRequest<ApiResponse<InventoryGroupDetailItemDto>>
    {
        [JsonPropertyName("filter_InventoryGroupDetailId")]
        public int? FilterInventoryGroupDetailId { get; set; }

        [JsonPropertyName("filter_InventoryGroupCode")]
        public string? FilterInventoryGroupCode { get; set; }

        [JsonPropertyName("filter_InventoryTypeCode")]
        public string? FilterInventoryTypeCode { get; set; }

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

