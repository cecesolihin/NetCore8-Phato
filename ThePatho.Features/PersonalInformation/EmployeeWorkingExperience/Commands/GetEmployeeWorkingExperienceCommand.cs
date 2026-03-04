using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands
{
    public class GetEmployeeWorkingExperienceCommand : IRequest<ApiResponse<EmployeeWorkingExperienceItemDto>>
    {
        [JsonPropertyName("filter_EmployeeId")]
        public int? FilterEmployeeId { get; set; }

        [JsonPropertyName("filter_WorkExperience")]
        public string? FilterWorkExperience { get; set; }


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

