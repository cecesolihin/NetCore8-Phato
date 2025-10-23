using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.FamilyRelation.Commands
{
    public class DeleteFamilyRelationCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("relation_code")]
        public string RelationCode { get; set; } = null!;
    }
}

