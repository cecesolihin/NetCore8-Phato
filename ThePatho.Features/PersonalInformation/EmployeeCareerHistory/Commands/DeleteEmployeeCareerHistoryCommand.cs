using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands
{
    public class DeleteEmployeeCareerHistoryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employeeId")]
        public int? EmployeeId { get; set; }

        [JsonPropertyName("careerHistoryNo")]
        public string CareerHistoryNo { get; set; } = null!;
    }
}

