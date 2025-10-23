using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ClothSize.Service;

namespace ThePatho.Features.Global.ClothSize.Commands
{
    public class DeleteClothSizeCommandHandler : IRequestHandler<DeleteClothSizeCommand, ApiResponse>
    {
        private readonly IClothSizeService clothSizeService;

        public DeleteClothSizeCommandHandler(IClothSizeService _clothSizeService)
        {
            clothSizeService = _clothSizeService;
        }

        public async Task<ApiResponse> Handle(DeleteClothSizeCommand request, CancellationToken cancellationToken)
        {
            return await clothSizeService.DeleteClothSize(request);
        }
    }
}
