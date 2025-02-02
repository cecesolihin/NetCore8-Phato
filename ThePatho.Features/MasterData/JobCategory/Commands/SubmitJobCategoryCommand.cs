using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class SubmitJobCategoryCommand : IRequest<ApiResponse>
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
