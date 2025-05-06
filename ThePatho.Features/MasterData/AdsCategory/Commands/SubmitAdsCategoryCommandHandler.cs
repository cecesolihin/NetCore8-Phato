using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.AdsCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class SubmitAdsCategoryCommandHandler : IRequestHandler<SubmitAdsCategoryCommand, ApiResponse>
    {
        private readonly IAdsCategoryService adsCategoryService;

        public SubmitAdsCategoryCommandHandler(IAdsCategoryService _adsCategoryService)
        {
            adsCategoryService = _adsCategoryService;
        }

        public async Task<ApiResponse> Handle(SubmitAdsCategoryCommand request, CancellationToken cancellationToken)
        {
            return await adsCategoryService.SubmitAdsCategory(request);
           
        }
    }
}
