using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePunishment.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeePunishment.Commands
{
    public class GetEmployeePunishmentCommand : IRequest<ApiResponse<EmployeePunishmentItemDto>>
    {
        [JsonPropertyName("filter_employeeId")]
        public int? FilterEmployeeId { get; set; }
        
        [JsonPropertyName("filter_punishment")]
        public string? FilterPunishment { get; set; }

        [JsonPropertyName("filter_letterDateFrom")]
        public DateTime? FilterLetterDateFrom { get; set; } = null;

        [JsonPropertyName("filter_letterDateTo")]
        public DateTime? FilterLetterDateTo { get; set; } = null;

        [JsonPropertyName("filter_validFrom")]
        public DateTime? FilterValidFrom { get; set; } = null;
        [JsonPropertyName("filter_validTo")]
        public DateTime? FilterValidTo { get; set; } = null;

        [JsonPropertyName("filter_recoveryDateFrom")]
        public DateTime? FilterRecoveryDateFrom { get; set; } = null;

        [JsonPropertyName("filter_recoveryDateTo")]
        public DateTime? FilterRecoveryDateTo { get; set; } = null;

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

