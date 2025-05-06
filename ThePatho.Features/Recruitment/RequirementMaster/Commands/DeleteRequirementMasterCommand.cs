using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class DeleteRequirementMasterCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("question_code")]
        public string QuestionCode { get; set; }
    }
}
