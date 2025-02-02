using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.AdsCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsCategoryByCriteriaCommandHandler : IRequestHandler<GetAdsCategoryByCriteriaCommand, NewApiResponse<AdsCategoryDto>>
    {
        private readonly IAdsCategoryService adsCategoryService;

        public GetAdsCategoryByCriteriaCommandHandler(IAdsCategoryService _adsCategoryService)
        {
            adsCategoryService = _adsCategoryService;
        }

        public async Task<NewApiResponse<AdsCategoryDto>> Handle(GetAdsCategoryByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await adsCategoryService.GetAdsCategoryByCriteria(request);
        }
    }
}
