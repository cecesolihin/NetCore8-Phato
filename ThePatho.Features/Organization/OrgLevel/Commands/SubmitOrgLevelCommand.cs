using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class SubmitOrgLevelCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("orgLevelCode")]
        public string OrgLevelCode { get; set; } = null!;

        [JsonPropertyName("orgLevelName")]
        public string OrgLevelName { get; set; } = null!;

        [JsonPropertyName("sort")]
        public byte Sort { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
