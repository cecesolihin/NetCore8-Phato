using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CostCenter.DTO;

namespace ThePatho.Features.Organization.CostCenter.Commands
{
    public class GetCostCenterCommand : IRequest<ApiResponse<CostCenterItemDto>>
    {
        [JsonPropertyName("filter_CostCenterCode")]
        public string? FilterCostCenterCode { get; set; }

        [JsonPropertyName("filter_CostCenterName")]
        public string? FilterCostCenterName { get; set; }

        [JsonPropertyName("filter_CostCenterType")]
        public string? FilterCostCenterType { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(0)]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}
