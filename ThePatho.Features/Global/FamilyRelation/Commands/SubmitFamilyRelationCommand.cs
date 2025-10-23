using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.FamilyRelation.Commands
{
    public class SubmitFamilyRelationCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("relation_code")]
        public string RelationCode { get; set; } = null!;

        [JsonPropertyName("relation_name")]
        public string RelationName { get; set; } = null!;
        [JsonPropertyName("relation_gender")]
        public string RelationGender { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

