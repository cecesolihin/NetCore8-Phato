using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands
{
    public class GetEmployeeCareerHistoryCommand : IRequest<ApiResponse<EmployeeCareerHistoryItemDto>>
    {
        [JsonPropertyName("filter_employeeId")]
        public int? FilterEmployeeId { get; set; }

        [JsonPropertyName("filter_careerHistory")]
        public string? FilterCareerHistory { get; set; }
        [JsonPropertyName("filter_effectiveDateFrom")]
        public DateTime? FilterEffectiveDateFrom { get; set; }

        [JsonPropertyName("filter_effectiveDateTo")]
        public DateTime? FilterEffectiveDateTo { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}

