using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands
{
    public class GetEmployeeCareerHistoryByCriteriaCommand : IRequest<ApiResponse<EmployeeCareerHistoryItemDto>>
    {
        [JsonPropertyName("employeeid")]
        public int? EmployeeId { get; set; }

        [JsonPropertyName("companycode")]
        public string? CompanyCode { get; set; }

        [JsonPropertyName("positioncode")]
        public string? PositionCode { get; set; }

        [JsonPropertyName("careerhistoryno")]
        public string? CareerHistoryNo { get; set; }

    }
}

