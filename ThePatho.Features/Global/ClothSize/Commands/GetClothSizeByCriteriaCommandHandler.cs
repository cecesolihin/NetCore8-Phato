using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ClothSize.Service;
using ThePatho.Features.Global.ClothSize.DTO;

namespace ThePatho.Features.Global.ClothSize.Commands
{
    public class GetClothSizeByCriteriaCommandHandler : IRequestHandler<GetClothSizeByCriteriaCommand, ApiResponse<ClothSizeItemDto>>
    {
        private readonly IClothSizeService clothSizeService;

        public GetClothSizeByCriteriaCommandHandler(IClothSizeService _clothSizeService)
        {
            clothSizeService = _clothSizeService;
        }

        public async Task<ApiResponse<ClothSizeItemDto>> Handle(GetClothSizeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await clothSizeService.GetClothSizeByCriteria(request);
        }
    }
}
