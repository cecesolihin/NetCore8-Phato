using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeEducation.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeEducation.Commands
{
    public class GetEmployeeEducationByCriteriaCommand : IRequest<ApiResponse<EmployeeEducationItemDto>>
    {
        [JsonPropertyName("employeeId")]
        public int? EmployeeId { get; set; }

        [JsonPropertyName("majorCode")]
        public string? MajorCode { get; set; }

        [JsonPropertyName("institution")]
        public string? Institution { get; set; }
    }
}

