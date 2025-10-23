using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Commands
{
    public class DeleteEmployeeSkillCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("skill_code")]
        public string SkillCode { get; set; } = null!;
    }
}

