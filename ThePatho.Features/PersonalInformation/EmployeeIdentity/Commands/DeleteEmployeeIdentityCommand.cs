using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands
{
    public class DeleteEmployeeIdentityCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("EduLevelCode")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("identitycode")]
        public string IdentityCode { get; set; } = null!;
    }
}

