using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsMedia.DTO;
using ThePatho.Features.MasterData.AdsMedia.Service;

namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class GetAdsMediaDdlCommandHandler : IRequestHandler<GetAdsMediaDdlCommand, ApiResponse<AdsMediaItemDto>>
    {
        private readonly IAdsMediaService adsMediaService; 

        public GetAdsMediaDdlCommandHandler(IAdsMediaService _adsMediaService)
        {
            adsMediaService = _adsMediaService;
        }

        public async Task<ApiResponse<AdsMediaItemDto>> Handle(GetAdsMediaDdlCommand request, CancellationToken cancellationToken)
        {
            return await adsMediaService.GetAdsMediaDdl(request);
        }
    }
}
