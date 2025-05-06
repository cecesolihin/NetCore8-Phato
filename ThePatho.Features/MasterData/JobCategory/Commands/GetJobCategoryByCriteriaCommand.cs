using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.JobCategory.DTO;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class GetJobCategoryByCriteriaCommand : IRequest<ApiResponse<JobCategoryDto>>
    {
        [JsonPropertyName("filter_JobCategoryCode")]
        public string? FilterJobCategoryCode { get; set; } 
        
    }
}
