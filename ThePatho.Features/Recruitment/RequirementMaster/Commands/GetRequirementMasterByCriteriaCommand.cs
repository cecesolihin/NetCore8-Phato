using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Recruitment.RequirementMaster.DTO;

namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{ 
    public class GetRequirementMasterByCriteriaCommand : IRequest<RequirementMasterItemDto>
    {
        [JsonPropertyName("filter_QuestionCode")]
        public string? FilterQuestionCode { get; set; }
    }
}
