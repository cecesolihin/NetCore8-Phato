using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class SubmitRequirementMasterCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("question_code")]
        public string QuestionCode { get; set; }

        [JsonPropertyName("question_name")]
        public string QuestionName { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
