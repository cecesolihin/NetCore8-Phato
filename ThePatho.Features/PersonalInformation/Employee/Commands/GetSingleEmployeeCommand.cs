using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.Employee.DTO;

namespace ThePatho.Features.PersonalInformation.Employee.Commands
{
    public class GetSingleEmployeeCommand : IRequest<ApiResponse<EmployeeDto>>
    {
        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

    }
}
