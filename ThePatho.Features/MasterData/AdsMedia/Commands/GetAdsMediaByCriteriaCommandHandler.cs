
using MediatR;
using ThePatho.Features.MasterData.AdsMedia.DTO;
using ThePatho.Features.MasterData.AdsMedia.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsMediaByCriteriaCommandHandler : IRequestHandler<GetAdsMediaByCriteriaCommand, AdsMediaDto>
    {
        private readonly IAdsMediaService adsMediaService;

        public GetAdsMediaByCriteriaCommandHandler(IAdsMediaService _adsMediaService)
        {
            adsMediaService = _adsMediaService;
        }

        public async Task<AdsMediaDto> Handle(GetAdsMediaByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await adsMediaService.GetAdsMediaByCriteria(request);

            return data;
        }
    }
}
