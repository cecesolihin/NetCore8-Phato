using MediatR;
using ThePatho.Features.MasterData.AdsCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class SubmitAdsCategoryCommandHandler : IRequestHandler<SubmitAdsCategoryCommand, string>
    {
        private readonly IAdsCategoryService adsCategoryService;

        public SubmitAdsCategoryCommandHandler(IAdsCategoryService _adsCategoryService)
        {
            adsCategoryService = _adsCategoryService;
        }

        public async Task<string> Handle(SubmitAdsCategoryCommand request, CancellationToken cancellationToken)
        {
            await adsCategoryService.SubmitAdsCategory(request);
            if (request.Action == "ADD")
            {
                return "Ads Category successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Ads Category successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
