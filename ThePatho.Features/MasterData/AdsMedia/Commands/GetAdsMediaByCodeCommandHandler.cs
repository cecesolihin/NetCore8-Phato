
using MediatR;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.AdsCategory.Service;
using ThePatho.Features.MasterData.AdsMedia.DTO;
using ThePatho.Features.MasterData.AdsMedia.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsMediaByCodeCommandHandler : IRequestHandler<GetAdsMediaByCodeCommand, AdsMediaDto>
    {
        private readonly IAdsMediaService adsMediaService;

        public GetAdsMediaByCodeCommandHandler(IAdsMediaService _adsMediaService)
        {
            adsMediaService = _adsMediaService;
        }

        public async Task<AdsMediaDto> Handle(GetAdsMediaByCodeCommand request, CancellationToken cancellationToken)
        {
            var data = await adsMediaService.GetAdsMediaByCode(request);

            return data;
        }
    }
}
