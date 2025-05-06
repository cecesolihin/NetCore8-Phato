using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.JobCategory.DTO;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class GetJobCategoryDdlCommand : IRequest<ApiResponse<JobCategoryItemDto>>
    {
        [JsonPropertyName("filter_JobCategoryCode")]
        public string? FilterJobCategoryCode { get; set; } 

    }
}
