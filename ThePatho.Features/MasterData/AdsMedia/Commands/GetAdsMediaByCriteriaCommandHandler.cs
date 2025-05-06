
using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsMedia.DTO;
using ThePatho.Features.MasterData.AdsMedia.Service;


namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class GetAdsMediaByCriteriaCommandHandler : IRequestHandler<GetAdsMediaByCriteriaCommand, ApiResponse<AdsMediaDto>>
    {
        private readonly IAdsMediaService adsMediaService;

        public GetAdsMediaByCriteriaCommandHandler(IAdsMediaService _adsMediaService)
        {
            adsMediaService = _adsMediaService;
        }

        public async Task<ApiResponse<AdsMediaDto>> Handle(GetAdsMediaByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await adsMediaService.GetAdsMediaByCriteria(request);
        }
    }
}
