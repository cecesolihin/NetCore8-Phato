using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands
{
    public class DeleteEmployeeIdentityCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("identity_code")]
        public string IdentityCode { get; set; } = null!;
    }
}

