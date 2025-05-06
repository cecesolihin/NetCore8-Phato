using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.AdsCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsCategoryDdlCommandHandler : IRequestHandler<GetAdsCategoryDdlCommand, ApiResponse<AdsCategoryItemDto>>
    {
        private readonly IAdsCategoryService adsCategoryService; 

        public GetAdsCategoryDdlCommandHandler(IAdsCategoryService _adsCategoryService)
        {
            adsCategoryService = _adsCategoryService;
        }

        public async Task<ApiResponse<AdsCategoryItemDto>> Handle(GetAdsCategoryDdlCommand request, CancellationToken cancellationToken)
        {
           return await adsCategoryService.GetAdsCategoriesDdl(request);

        }
    }
}
