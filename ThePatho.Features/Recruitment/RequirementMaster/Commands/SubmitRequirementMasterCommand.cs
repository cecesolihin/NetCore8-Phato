using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class SubmitRequirementMasterCommand : IRequest<string>
    {
        [JsonPropertyName("question_code")]
        public string QuestionCode { get; set; }

        [JsonPropertyName("question_name")]
        public string QuestionName { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
