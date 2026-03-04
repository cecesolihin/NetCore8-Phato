using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeSkill.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Commands
{
    public class GetSingleEmployeeSkillCommand : IRequest<ApiResponse<EmployeeSkillDto>>
    {
        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("skillCode")]
        public string SkillCode { get; set; } = null!;

    }
}
