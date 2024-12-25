using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;

namespace ThePatho.Features.Recruitment.RequirementRecRequest.Commands
{
    public class GetRequirementRecRequestByCriteriaCommand :IRequest<RequirementRecRequestItemDto>
    {
        [JsonPropertyName("filter_RequestNo")]
        public string? FilterRequestNo { get; set; }
    }
}
