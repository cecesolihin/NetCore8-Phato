using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Domain.Models.MasterData;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.AdsCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsCategoryByCodeCommandHandler : IRequestHandler<GetAdsCategoryByCodeCommand, AdsCategoryDto>
    {
        private readonly IAdsCategoryService adsCategoryService;

        public GetAdsCategoryByCodeCommandHandler(IAdsCategoryService _adsCategoryService)
        {
            adsCategoryService = _adsCategoryService;
        }

        public async Task<AdsCategoryDto> Handle(GetAdsCategoryByCodeCommand request, CancellationToken cancellationToken)
        {
            var data = await adsCategoryService.GetAdsCategoryByCode(request);

            return data;
        }
    }
}
