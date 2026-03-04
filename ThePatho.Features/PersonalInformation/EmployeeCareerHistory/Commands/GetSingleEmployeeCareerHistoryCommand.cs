using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands
{
    public class GetSingleEmployeeCareerHistoryCommand : IRequest<ApiResponse<EmployeeCareerHistoryDto>>
    {
        [JsonPropertyName("employeeId")]
        public int? EmployeeId { get; set; }

        [JsonPropertyName("careerHistoryNo")]
        public string CareerHistoryNo { get; set; } = null!;

    }
}
