using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.JobCategory.DTO;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class GetJobCategoryCommand: IRequest<ApiResponse<JobCategoryItemDto>>
    {
        [JsonPropertyName("filter_JobCategoryCode")]
        public string? FilterJobCategoryCode { get; set; }

        [JsonPropertyName("filter_JobCategoryName")]
        public string? FilterJobCategoryName { get; set; }

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
