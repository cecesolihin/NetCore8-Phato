
using MediatR;
using ThePatho.Features.MasterData.AdsMedia.DTO;
using ThePatho.Features.MasterData.AdsMedia.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsMediaCommandHandler : IRequestHandler<GetAdsMediaCommand, AdsMediaItemDto>
    {
        private readonly IAdsMediaService adsMediaService;

        public GetAdsMediaCommandHandler(IAdsMediaService _adsMediaService)
        {
            adsMediaService = _adsMediaService;
        }

        public async Task<AdsMediaItemDto> Handle(GetAdsMediaCommand request, CancellationToken cancellationToken)
        {
            var categories = await adsMediaService.GetAdsMedia(request);

            return new AdsMediaItemDto
            {
                DataOfRecords = categories.Count,
                AdsMediaList = categories
            };
        }
    }
}
