using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands
{
    public class GetEmployeeCareerHistoryByCriteriaCommand : IRequest<ApiResponse<EmployeeCareerHistoryItemDto>>
    {
        [JsonPropertyName("filter_employee_id")]
        public int? FilterEmployeeId { get; set; }

        [JsonPropertyName("filter_company_code")]
        public string? FilterCompanyCode { get; set; }

        [JsonPropertyName("filter_position_code")]
        public string? FilterPositionCode { get; set; }

        [JsonPropertyName("filter_career_history_no")]
        public string? FilterCareerHistoryNo { get; set; }
        
    }
}

