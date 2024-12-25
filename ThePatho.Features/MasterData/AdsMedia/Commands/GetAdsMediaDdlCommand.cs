using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.MasterData.AdsMedia.DTO;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsMediaDdlCommand : IRequest<AdsMediaItemDto>
    {
        [JsonPropertyName("filter_AdsCategoryCode")]
        public string? FilterAdsCategoryCode { get; set; }
       
       
    }
}
