using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class DeleteRequirementMasterCommand : IRequest<bool>
    {
        [JsonPropertyName("question_code")]
        public string QuestionCode { get; set; }
    }
}
