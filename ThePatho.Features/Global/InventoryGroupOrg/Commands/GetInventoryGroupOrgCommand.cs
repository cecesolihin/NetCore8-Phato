using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupOrg.DTO;

namespace ThePatho.Features.Global.InventoryGroupOrg.Commands
{
    public class GetInventoryGroupOrgCommand : IRequest<ApiResponse<InventoryGroupOrgItemDto>>
    {
        [JsonPropertyName("filter_InventoryGroupCode")]
        public string? FilterInventoryGroupCode { get; set; }

        [JsonPropertyName("filter_OrganizationCode")]
        public string? FilterOrganizationCode { get; set; }

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

