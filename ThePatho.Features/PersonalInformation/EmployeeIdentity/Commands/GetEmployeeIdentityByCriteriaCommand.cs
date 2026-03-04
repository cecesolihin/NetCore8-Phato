using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands
{
    public class GetEmployeeIdentityByCriteriaCommand : IRequest<ApiResponse<EmployeeIdentityItemDto>>
    {
        [JsonPropertyName("employeeId")]
        public int? EmployeeId { get; set; }

        [JsonPropertyName("identityCode")]
        public string? IdentityCode { get; set; }

        [JsonPropertyName("identityno")]
        public string? IdentityNo { get; set; }
    }
}

