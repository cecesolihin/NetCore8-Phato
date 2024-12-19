using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.MasterData.JobCategory.DTO;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class GetJobCategoryByCriteriaCommand : IRequest<JobCategoryDto>
    {
        [JsonPropertyName("filter_JobCategoryCode")]
        public string? FilterJobCategoryCode { get; set; }
        
    }
}
