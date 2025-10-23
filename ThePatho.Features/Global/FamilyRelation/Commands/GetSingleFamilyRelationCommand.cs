using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.FamilyRelation.DTO;

namespace ThePatho.Features.Global.FamilyRelation.Commands
{
    public class GetSingleFamilyRelationCommand : IRequest<ApiResponse<FamilyRelationDto>>
    {
        [JsonPropertyName("filter_RelationCode")]
        public string FilterRelationCode { get; set; } = null!;

    }
}
