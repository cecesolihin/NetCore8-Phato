using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePunishment.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeePunishment.Commands
{
    public class GetEmployeePunishmentCommand : IRequest<ApiResponse<EmployeePunishmentItemDto>>
    {

        [JsonPropertyName("filter_letter_no")]
        public string FilterLetterNo { get; set; } = null!;

        [JsonPropertyName("filter_employee_id")]
        public int FilterEmployeeId { get; set; }

        [JsonPropertyName("filter_letter_date")]
        public string FilterLetterDate { get; set; } = null!;
        [JsonPropertyName("filter_punishment_type")]
        public string FilterPunishmentType { get; set; } = null!;

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

