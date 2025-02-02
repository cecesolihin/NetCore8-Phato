using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class DeleteJobCategoryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("job_category_code")]
        public string JobCategoryCode { get; set; }

        public DeleteJobCategoryCommand(string jobCategoryCode)
        {
            JobCategoryCode = jobCategoryCode;
        }
    }
}
