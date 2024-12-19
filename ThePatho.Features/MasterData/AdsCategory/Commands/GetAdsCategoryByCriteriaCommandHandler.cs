using MediatR;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.AdsCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsCategoryByCriteriaCommandHandler : IRequestHandler<GetAdsCategoryByCriteriaCommand, AdsCategoryDto>
    {
        private readonly IAdsCategoryService adsCategoryService;

        public GetAdsCategoryByCriteriaCommandHandler(IAdsCategoryService _adsCategoryService)
        {
            adsCategoryService = _adsCategoryService;
        }

        public async Task<AdsCategoryDto> Handle(GetAdsCategoryByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await adsCategoryService.GetAdsCategoryByCode(request);

            return data;
        }
    }
}
