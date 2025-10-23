using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands
{
    public class GetEmployeeIdentityByCriteriaCommand : IRequest<ApiResponse<EmployeeIdentityItemDto>>
    {
        [JsonPropertyName("filter_employee_id")]
        public int? FilterEmployeeId { get; set; }

        [JsonPropertyName("filter_identity_code")]
        public string? FilterIdentityCode { get; set; }

        [JsonPropertyName("filter_identity_no")]
        public string? FilterIdentityNo { get; set; }
    }
}

