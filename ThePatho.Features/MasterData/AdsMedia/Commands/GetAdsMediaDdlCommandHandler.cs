using MediatR;

using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.AdsMedia.DTO;
using ThePatho.Features.MasterData.AdsMedia.Service;

namespace ThePatho.Features.MasterData.AdsMedia.Commands
{
    public class GetAdsMediaDdlCommandHandler : IRequestHandler<GetAdsMediaDdlCommand, AdsMediaItemDto>
    {
        private readonly IAdsMediaService adsMediaService; 

        public GetAdsMediaDdlCommandHandler(IAdsMediaService _adsMediaService)
        {
            adsMediaService = _adsMediaService;
        }

        public async Task<AdsMediaItemDto> Handle(GetAdsMediaDdlCommand request, CancellationToken cancellationToken)
        {
            var data = await adsMediaService.GetAdsMediaDdl(request);

            return new AdsMediaItemDto
            {
                DataOfRecords = data.Count,
                AdsMediaList = data
            };
        }
    }
}
