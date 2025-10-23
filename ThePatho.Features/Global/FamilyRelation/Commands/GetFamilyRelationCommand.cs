using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.FamilyRelation.DTO;

namespace ThePatho.Features.Global.FamilyRelation.Commands
{
    public class GetFamilyRelationCommand : IRequest<ApiResponse<FamilyRelationItemDto>>
    {
        [JsonPropertyName("filter_RelationName")]
        public string? FilterRelationName { get; set; }

        [JsonPropertyName("filter_RelationCode")]
        public string? FilterRelationCode { get; set; }

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

