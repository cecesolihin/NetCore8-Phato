using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class SubmitJobCategoryCommand : IRequest<string>
    {
        [JsonPropertyName("JobCategoryCode")]
        public string JobCategoryCode { get; set; }

        [JsonPropertyName("JobCategoryName")]
        public string JobCategoryName { get; set; }

        [JsonPropertyName("IsCategory")]
        public bool IsCategory { get; set; }

        [JsonPropertyName("ParentCategory")]
        public int? ParentCategory { get; set; }

        [JsonPropertyName("Action")]
        public string Action { get; set; } // "ADD" or "EDIT"
    }
}
