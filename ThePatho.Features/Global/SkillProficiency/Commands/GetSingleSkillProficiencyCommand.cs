using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.SkillProficiency.DTO;

namespace ThePatho.Features.Global.SkillProficiency.Commands
{
    public class GetSingleSkillProficiencyCommand : IRequest<ApiResponse<SkillProficiencyDto>>
    {
        [JsonPropertyName("filter_ProfiencyCode")]
        public string FilterProfiencyCode { get; set; } = null!;
    }
}
