using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands
{
    public class GetEmployeeWorkingExperienceByCriteriaCommand : IRequest<ApiResponse<EmployeeWorkingExperienceItemDto>>
    {
        [JsonPropertyName("filter_EmployeeId")]
        public int? FilterEmployeeId { get; set; }

        [JsonPropertyName("filter_Company")]
        public string? FilterCompany { get; set; }

        [JsonPropertyName("filter_EmploymentTypeCode")]
        public string? FilterEmploymentTypeCode { get; set; }
    }
}

