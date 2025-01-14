using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Organization.OrgLevel.DTO;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class GetOrgLevelCommand :IRequest<OrganizationLevelItemDto>
    {
        [JsonPropertyName("filter_OrgLevelName")]
        public string? FilterOrgLevelName { get; set; }
        [JsonPropertyName("filter_OrgLevelCode")]
        public string? FilterOrgLevelCode { get; set; }

        [JsonPropertyName("sortBy")]
        public string? SortBy { get; set; } = "InsertedDate";
        [JsonPropertyName("orderBy")]
        public string? OrderBy { get; set; } = "DESC";
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; } = 0;
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 10; 
    }
}
