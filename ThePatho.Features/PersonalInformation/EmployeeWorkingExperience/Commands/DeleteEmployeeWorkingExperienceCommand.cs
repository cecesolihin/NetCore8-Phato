using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands
{
    public class DeleteEmployeeWorkingExperienceCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("emp_work_experience_id")]
        public int EmpWorkExperienceId { get; set; }
    }
}

