
using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsMedia.DTO;
using ThePatho.Features.MasterData.AdsMedia.Service;

namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class GetAdsMediaCommandHandler : IRequestHandler<GetAdsMediaCommand, ApiResponse<AdsMediaItemDto>>
    {
        private readonly IAdsMediaService adsMediaService;

        public GetAdsMediaCommandHandler(IAdsMediaService _adsMediaService) 
        {
            adsMediaService = _adsMediaService;
        }

        public async Task<ApiResponse<AdsMediaItemDto>> Handle(GetAdsMediaCommand request, CancellationToken cancellationToken)
        {
            return await adsMediaService.GetAdsMedia(request);
        }
    }
}
