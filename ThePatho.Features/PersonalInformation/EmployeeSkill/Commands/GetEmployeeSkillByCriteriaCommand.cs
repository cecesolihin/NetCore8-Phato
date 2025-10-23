using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeSkill.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Commands
{
    public class GetEmployeeSkillByCriteriaCommand : IRequest<ApiResponse<EmployeeSkillItemDto>>
    {
        [JsonPropertyName("filter_EmployeeId")]
        public int? FilterEmployeeId { get; set; }

        [JsonPropertyName("filter_SkillCode")]
        public string? FilterSkillCode { get; set; }

        [JsonPropertyName("filter_ProfiencyCode")]
        public string? FilterProfiencyCode { get; set; }
    }
}

