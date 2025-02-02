using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.OrgStructure.DTO;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class GetOrgStructureCommand :IRequest<NewApiResponse<OrgStructureItemDto>>
    {
        [JsonPropertyName("filter_OrgStructureName")]
        public string? FilterOrgStructureName { get; set; }
        [JsonPropertyName("filter_OrgStructureCode")]
        public string? FilterOrgStructureCode { get; set; }
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
