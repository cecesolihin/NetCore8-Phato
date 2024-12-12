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
    public class GetAdsCategoryCommandHandler : IRequestHandler<GetAdsCategoryCommand, AdsCategoryItemDto>
    {
        private readonly IAdsCategoryService _adsCategoryService;

        public GetAdsCategoryCommandHandler(IAdsCategoryService adsCategoryService)
        {
            _adsCategoryService = adsCategoryService;
        }

        public async Task<AdsCategoryItemDto> Handle(GetAdsCategoryCommand request, CancellationToken cancellationToken)
        {
            var categories = await _adsCategoryService.GetAllAdsCategoriesAsync(request);

            return new AdsCategoryItemDto
            {
                DataOfRecords = categories.Count,
                AdsCategoryList = categories
            };
        }
    }
}
