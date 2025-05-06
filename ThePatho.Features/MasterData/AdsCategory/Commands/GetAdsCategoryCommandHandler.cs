using MediatR;
using System.Net;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.AdsCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsCategoryCommandHandler : IRequestHandler<GetAdsCategoryCommand, ApiResponse<AdsCategoryItemDto>>
    {
        private readonly IAdsCategoryService adsCategoryService; 

        public GetAdsCategoryCommandHandler(IAdsCategoryService _adsCategoryService)
        {
            adsCategoryService = _adsCategoryService;
        }

        public async Task<ApiResponse<AdsCategoryItemDto>> Handle(GetAdsCategoryCommand request, CancellationToken cancellationToken)
        {
            return await adsCategoryService.GetAllAdsCategories(request);
        }
    }
}
