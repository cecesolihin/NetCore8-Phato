using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeEducation.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeEducation.Commands
{
    public class GetSingleEmployeeEducationCommand : IRequest<ApiResponse<EmployeeEducationDto>>
    {
        [JsonPropertyName("employee_education_id")]
        public int EmployeeEducationId { get; set; }

    }
}
