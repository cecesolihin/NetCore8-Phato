using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ClothSize.Service;

namespace ThePatho.Features.Global.ClothSize.Commands
{
    public class SubmitClothSizeCommandHandler : IRequestHandler<SubmitClothSizeCommand, ApiResponse>
    {
        private readonly IClothSizeService clothSizeService;

        public SubmitClothSizeCommandHandler(IClothSizeService _clothSizeService)
        {
            clothSizeService = _clothSizeService;
        }

        public async Task<ApiResponse> Handle(SubmitClothSizeCommand request, CancellationToken cancellationToken)
        {
            return await clothSizeService.SubmitClothSize(request);
        }
    }
}
