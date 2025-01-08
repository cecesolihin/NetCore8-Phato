using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.MasterData.AdsMedia.DTO;

namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class GetAdsMediaByCriteriaCommand : IRequest<AdsMediaDto>
    {
        [JsonPropertyName("filter_AdsCode")]
        public string? FilterAdsCode { get; set; } 
        
    }
}
