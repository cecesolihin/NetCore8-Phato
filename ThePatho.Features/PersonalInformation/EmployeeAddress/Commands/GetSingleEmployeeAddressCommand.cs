using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeAddress.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeAddress.Commands
{
    public class GetSingleEmployeeAddressCommand : IRequest<ApiResponse<EmployeeAddressDto>>
    {
        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

    }
}
