using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class DeleteAdsMediaCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("ads_media_code")]
        public string AdsMediaCode { get; set; }

        public DeleteAdsMediaCommand(string AdsMediaCode)
        {
            AdsMediaCode = AdsMediaCode;
        }
    }
}
