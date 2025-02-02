using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.AdsCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsCategoryDdlCommandHandler : IRequestHandler<GetAdsCategoryDdlCommand, NewApiResponse<AdsCategoryItemDto>>
    {
        private readonly IAdsCategoryService adsCategoryService; 

        public GetAdsCategoryDdlCommandHandler(IAdsCategoryService _adsCategoryService)
        {
            adsCategoryService = _adsCategoryService;
        }

        public async Task<NewApiResponse<AdsCategoryItemDto>> Handle(GetAdsCategoryDdlCommand request, CancellationToken cancellationToken)
        {
           return await adsCategoryService.GetAdsCategoriesDdl(request);

        }
    }
}
