using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeReward.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Commands
{
    public class GetEmployeeRewardCommand : IRequest<ApiResponse<EmployeeRewardItemDto>>
    {
        [JsonPropertyName("filter_letter_no")]
        public string? FilterLetterNo { get; set; }

        [JsonPropertyName("filter_employee_id")]
        public int? FilterEmployeeId { get; set; }

        [JsonPropertyName("filter_reward_type_code")]
        public string? FilterRewardTypeCode { get; set; }

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

