using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ClothSize.Service;
using ThePatho.Features.Global.ClothSize.DTO;

namespace ThePatho.Features.Global.ClothSize.Commands
{
    public class GetClothSizeCommandHandler : IRequestHandler<GetClothSizeCommand, ApiResponse<ClothSizeItemDto>>
    {
        private readonly IClothSizeService clothSizeService;

        public GetClothSizeCommandHandler(IClothSizeService _clothSizeService)
        {
            clothSizeService = _clothSizeService;
        }

        public async Task<ApiResponse<ClothSizeItemDto>> Handle(GetClothSizeCommand request, CancellationToken cancellationToken)
        {
            return await clothSizeService.GetClothSize(request);
        }
    }
}
