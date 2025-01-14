using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class DeleteRecruitmentRequestCommand : IRequest<bool>
    {
        [JsonPropertyName("filter_RequestNo")]
        public string RequestNo { get; set; }
    }
}
