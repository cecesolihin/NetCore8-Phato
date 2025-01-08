using MediatR;

namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class DeleteAdsMediaCommand : IRequest<bool>
    {
        public string AdsMediaCode { get; set; }

        public DeleteAdsMediaCommand(string AdsMediaCode)
        {
            AdsMediaCode = AdsMediaCode;
        }
    }
}
