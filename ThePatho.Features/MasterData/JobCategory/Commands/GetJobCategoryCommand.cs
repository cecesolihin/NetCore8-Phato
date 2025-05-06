using MediatR;
using System.Text.Json.Serialization;
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
        public string? SortBy { get; set; } = "InsertedDate";
        [JsonPropertyName("orderBy")]
        public string? OrderBy { get; set; } = "DESC";
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; } = 0;
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 10; 
    }
}
