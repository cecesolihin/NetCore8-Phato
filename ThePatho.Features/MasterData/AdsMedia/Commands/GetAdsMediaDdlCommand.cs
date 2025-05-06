using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsMedia.DTO;

namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class GetAdsMediaDdlCommand : IRequest<ApiResponse<AdsMediaItemDto>>
    {
        [JsonPropertyName("filter_AdsCategoryCode")]
        public string? FilterAdsCategoryCode { get; set; }
       
       
    }
}
