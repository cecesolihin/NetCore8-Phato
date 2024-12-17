﻿using MediatR;
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
    public class GetAdsCategoryDdlCommandHandler : IRequestHandler<GetAdsCategoryDdlCommand, AdsCategoryItemDto>
    {
        private readonly IAdsCategoryService adsCategoryService;

        public GetAdsCategoryDdlCommandHandler(IAdsCategoryService _adsCategoryService)
        {
            adsCategoryService = _adsCategoryService;
        }

        public async Task<AdsCategoryItemDto> Handle(GetAdsCategoryDdlCommand request, CancellationToken cancellationToken)
        {
            var data = await adsCategoryService.GetAdsCategoriesDdl(request);

            return new AdsCategoryItemDto
            {
                DataOfRecords = data.Count,
                AdsCategoryList = data
            };
        }
    }
}
