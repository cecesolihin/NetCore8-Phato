using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands
{
    public class DeleteEmployeeWorkingExperienceCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("EmpWorkExperienceId")]
        public int EmpWorkExperienceId { get; set; }
    }
}

