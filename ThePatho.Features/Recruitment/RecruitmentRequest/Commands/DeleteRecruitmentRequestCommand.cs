using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class DeleteRecruitmentRequestCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("filter_RequestNo")]
        public string RequestNo { get; set; }
    }
}
