using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands
{
    public class GetEmployeeWorkingExperienceByCriteriaCommand : IRequest<ApiResponse<EmployeeWorkingExperienceItemDto>>
    {
        [JsonPropertyName("employeeId")]
        public int? EmployeeId { get; set; }

        [JsonPropertyName("company")]
        public string? Company { get; set; }

        [JsonPropertyName("employmentTypeCode")]
        public string? EmploymentTypeCode { get; set; }
    }
}

