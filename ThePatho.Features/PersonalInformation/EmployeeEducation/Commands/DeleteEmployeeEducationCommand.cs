using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeEducation.Commands
{
    public class DeleteEmployeeEducationCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_education_id")]
        public int EmployeeEducationId { get; set; }
    }
}

