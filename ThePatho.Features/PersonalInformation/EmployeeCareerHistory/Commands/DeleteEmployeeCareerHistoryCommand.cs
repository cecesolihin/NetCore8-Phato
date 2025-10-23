using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands
{
    public class DeleteEmployeeCareerHistoryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_id")]
        public int? EmployeeId { get; set; }

        [JsonPropertyName("career_history_no")]
        public string CareerHistoryNo { get; set; } = null!;
    }
}

