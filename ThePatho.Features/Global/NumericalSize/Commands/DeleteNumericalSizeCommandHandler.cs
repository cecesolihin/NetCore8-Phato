using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.NumericalSize.Service;

namespace ThePatho.Features.Global.NumericalSize.Commands
{
    public class DeleteNumericalSizeCommandHandler : IRequestHandler<DeleteNumericalSizeCommand, ApiResponse>
    {
        private readonly INumericalSizeService numericalSizeService;

        public DeleteNumericalSizeCommandHandler(INumericalSizeService _numericalSizeService)
        {
            numericalSizeService = _numericalSizeService;
        }

        public async Task<ApiResponse> Handle(DeleteNumericalSizeCommand request, CancellationToken cancellationToken)
        {
            return await numericalSizeService.DeleteNumericalSize(request);
        }
    }
}
