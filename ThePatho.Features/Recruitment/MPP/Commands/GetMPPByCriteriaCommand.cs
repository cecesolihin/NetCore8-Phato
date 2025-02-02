using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.MPP.DTO;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class GetMPPByCriteriaCommand :IRequest<NewApiResponse<MPPDto>> 
    {
        [JsonPropertyName("filter_MPPNo")]
        public string? FilterMPPNo { get; set; }
    }
}
