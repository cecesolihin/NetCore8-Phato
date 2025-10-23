using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ClothSize.Service;
using ThePatho.Features.Global.ClothSize.DTO;

namespace ThePatho.Features.Global.ClothSize.Commands
{
    public class GetSingleClothSizeCommandHandler : IRequestHandler<GetSingleClothSizeCommand, ApiResponse<ClothSizeDto>>
    {
        private readonly IClothSizeService clothSizeService;

        public GetSingleClothSizeCommandHandler(IClothSizeService _clothSizeService)
        {
            clothSizeService = _clothSizeService;
        }

        public async Task<ApiResponse<ClothSizeDto>> Handle(GetSingleClothSizeCommand request, CancellationToken cancellationToken)
        {
            return await clothSizeService.GetSingleClothSize(request);
        }
    }
}
