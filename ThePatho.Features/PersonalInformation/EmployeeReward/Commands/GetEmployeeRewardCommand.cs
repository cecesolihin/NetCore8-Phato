using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeReward.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Commands
{
    public class GetEmployeeRewardCommand : IRequest<ApiResponse<EmployeeRewardItemDto>>
    {

        [JsonPropertyName("filter_EmployeeId")]
        public int? FilterEmployeeId { get; set; }

        [JsonPropertyName("filter_reward")]
        public string? FilterReward { get; set; }
        [JsonPropertyName("filter_letterDateFrom")]
        public DateTime? FilterLetterDateFrom { get; set; } = null;

        [JsonPropertyName("filter_letterDateTo")]
        public DateTime? FilterLetterDateTo { get; set; } = null;

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

