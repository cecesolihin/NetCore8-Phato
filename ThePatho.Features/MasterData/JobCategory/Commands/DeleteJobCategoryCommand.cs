using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class DeleteJobCategoryCommand : IRequest<bool>
    {
        [JsonPropertyName("job_category_code")]
        public string JobCategoryCode { get; set; }

        public DeleteJobCategoryCommand(string jobCategoryCode)
        {
            JobCategoryCode = jobCategoryCode;
        }
    }
}
