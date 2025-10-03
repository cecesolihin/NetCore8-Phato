using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgLevel.DTO;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class GetOrgLevelCommand :IRequest<ApiResponse<OrgLevelItemDto>>
    {
        [JsonPropertyName("filter_OrgLevelName")]
        public string? FilterOrgLevelName { get; set; }

        [JsonPropertyName("filter_OrgLevelCode")]
        public string? FilterOrgLevelCode { get; set; }

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
