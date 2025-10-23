using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.NumericalSize.Service;

namespace ThePatho.Features.Global.NumericalSize.Commands
{
    public class SubmitNumericalSizeCommandHandler : IRequestHandler<SubmitNumericalSizeCommand, ApiResponse>
    {
        private readonly INumericalSizeService numericalSizeService;

        public SubmitNumericalSizeCommandHandler(INumericalSizeService _numericalSizeService)
        {
            numericalSizeService = _numericalSizeService;
        }

        public async Task<ApiResponse> Handle(SubmitNumericalSizeCommand request, CancellationToken cancellationToken)
        {
            return await numericalSizeService.SubmitNumericalSize(request);
        }
    }
}
