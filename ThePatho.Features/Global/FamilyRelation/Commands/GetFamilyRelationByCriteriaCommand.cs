using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.FamilyRelation.DTO;

namespace ThePatho.Features.Global.FamilyRelation.Commands
{
    public class GetFamilyRelationByCriteriaCommand : IRequest<ApiResponse<FamilyRelationItemDto>>
    {
        [JsonPropertyName("relationName")]
        public string? RelationName { get; set; }

        [JsonPropertyName("relationCode")]
        public string? RelationCode { get; set; }
    }
}

