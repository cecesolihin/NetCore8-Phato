using MediatR;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.AdsCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsCategoryCommandHandler : IRequestHandler<GetAdsCategoryCommand, AdsCategoryItemDto>
    {
        private readonly IAdsCategoryService adsCategoryService; 

        public GetAdsCategoryCommandHandler(IAdsCategoryService _adsCategoryService)
        {
            adsCategoryService = _adsCategoryService;
        }

        public async Task<AdsCategoryItemDto> Handle(GetAdsCategoryCommand request, CancellationToken cancellationToken)
        {
            var data = await adsCategoryService.GetAllAdsCategories(request);

            return new AdsCategoryItemDto
            {
                DataOfRecords = data.Count,
                AdsCategoryList = data
            };
        }
    }
}
