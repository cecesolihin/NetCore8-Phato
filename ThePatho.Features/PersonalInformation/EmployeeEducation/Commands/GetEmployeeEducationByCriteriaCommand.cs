using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeEducation.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeEducation.Commands
{
    public class GetEmployeeEducationByCriteriaCommand : IRequest<ApiResponse<EmployeeEducationItemDto>>
    {
        [JsonPropertyName("filter_employee_id")]
        public int? FilterEmployeeId { get; set; }

        [JsonPropertyName("filter_major_code")]
        public string? FilterMajorCode { get; set; }

        [JsonPropertyName("filter_institution")]
        public string? FilterInstitution { get; set; }
    }
}

