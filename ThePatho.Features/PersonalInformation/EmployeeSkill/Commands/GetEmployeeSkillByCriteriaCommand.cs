using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeSkill.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Commands
{
    public class GetEmployeeSkillByCriteriaCommand : IRequest<ApiResponse<EmployeeSkillItemDto>>
    {
        [JsonPropertyName("employeeId")]
        public int? EmployeeId { get; set; }

        [JsonPropertyName("skillCode")]
        public string? SkillCode { get; set; }

        [JsonPropertyName("profiencyCode")]
        public string? ProfiencyCode { get; set; }
    }
}

