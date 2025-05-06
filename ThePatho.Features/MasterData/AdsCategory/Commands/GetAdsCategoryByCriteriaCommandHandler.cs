using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.AdsCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsCategoryByCriteriaCommandHandler : IRequestHandler<GetAdsCategoryByCriteriaCommand, ApiResponse<AdsCategoryDto>>
    {
        private readonly IAdsCategoryService adsCategoryService;

        public GetAdsCategoryByCriteriaCommandHandler(IAdsCategoryService _adsCategoryService)
        {
            adsCategoryService = _adsCategoryService;
        }

        public async Task<ApiResponse<AdsCategoryDto>> Handle(GetAdsCategoryByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await adsCategoryService.GetAdsCategoryByCriteria(request);
        }
    }
}
