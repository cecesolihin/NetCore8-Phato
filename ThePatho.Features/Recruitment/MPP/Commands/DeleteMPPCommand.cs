using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class DeleteMPPCommand : IRequest<bool>
    {
        [JsonPropertyName("mpp_no")]
        public string MPPNo { get; set; }
    }
}
