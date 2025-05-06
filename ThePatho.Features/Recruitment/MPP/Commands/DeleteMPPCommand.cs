using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class DeleteMPPCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("mpp_no")]
        public string MPPNo { get; set; }
    }
}
