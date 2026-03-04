using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Commands
{
    public class DeleteEmployeeSkillCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("skillCode")]
        public string SkillCode { get; set; } = null!;
    }
}

