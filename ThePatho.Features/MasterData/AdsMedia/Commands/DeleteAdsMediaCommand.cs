using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class DeleteAdsMediaCommand : IRequest<bool>
    {
        [JsonPropertyName("ads_media_code")]
        public string AdsMediaCode { get; set; }

        public DeleteAdsMediaCommand(string AdsMediaCode)
        {
            AdsMediaCode = AdsMediaCode;
        }
    }
}
