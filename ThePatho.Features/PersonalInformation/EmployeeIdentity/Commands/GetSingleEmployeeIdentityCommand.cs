using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands
{
    public class GetSingleEmployeeIdentityCommand : IRequest<ApiResponse<EmployeeIdentityDto>>
    {
        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("identity_code")]
        public string IdentityCode { get; set; } = null!;

    }
}
