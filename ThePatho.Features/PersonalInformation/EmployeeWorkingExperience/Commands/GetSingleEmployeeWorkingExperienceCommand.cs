using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands
{
    public class GetSingleEmployeeWorkingExperienceCommand : IRequest<ApiResponse<EmployeeWorkingExperienceDto>>
    {
        [JsonPropertyName("empWorkExperienceId")]
        public int EmpWorkExperienceId { get; set; }

    }
}
