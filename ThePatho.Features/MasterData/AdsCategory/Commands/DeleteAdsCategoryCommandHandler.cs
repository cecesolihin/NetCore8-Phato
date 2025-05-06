
using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class DeleteAdsCategoryCommandHandler : IRequestHandler<DeleteAdsCategoryCommand, ApiResponse>
    {
        private readonly IAdsCategoryService adsCategoryService;

        public DeleteAdsCategoryCommandHandler(IAdsCategoryService _adsCategoryService)
        {
            adsCategoryService = _adsCategoryService;
        }

        public async Task<ApiResponse> Handle(DeleteAdsCategoryCommand request, CancellationToken cancellationToken)
        {
            return await adsCategoryService.DeleteAdsCategory(request);  
        }
    }

}
