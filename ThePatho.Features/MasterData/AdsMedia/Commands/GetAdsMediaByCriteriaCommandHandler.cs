
using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.AdsMedia.DTO;
using ThePatho.Features.MasterData.AdsMedia.Service;


namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class GetAdsMediaByCriteriaCommandHandler : IRequestHandler<GetAdsMediaByCriteriaCommand, NewApiResponse<AdsMediaDto>>
    {
        private readonly IAdsMediaService adsMediaService;

        public GetAdsMediaByCriteriaCommandHandler(IAdsMediaService _adsMediaService)
        {
            adsMediaService = _adsMediaService;
        }

        public async Task<NewApiResponse<AdsMediaDto>> Handle(GetAdsMediaByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await adsMediaService.GetAdsMediaByCriteria(request);
        }
    }
}
