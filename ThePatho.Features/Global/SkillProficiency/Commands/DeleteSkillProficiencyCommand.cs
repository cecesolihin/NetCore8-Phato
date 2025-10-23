using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.SkillProficiency.Commands
{
    public class DeleteSkillProficiencyCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("profiency_code")]
        public string ProfiencyCode { get; set; } = null!;
    }
}
