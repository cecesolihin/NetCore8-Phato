
using MediatR;
using ThePatho.Features.MasterData.AdsCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class DeleteAdsCategoryCommandHandler : IRequestHandler<DeleteAdsCategoryCommand, bool>
    {
        private readonly IAdsCategoryService adsCategoryService;

        public DeleteAdsCategoryCommandHandler(IAdsCategoryService _adsCategoryService)
        {
            adsCategoryService = _adsCategoryService;
        }

        public async Task<bool> Handle(DeleteAdsCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await adsCategoryService.DeleteAdsCategory(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }

}
