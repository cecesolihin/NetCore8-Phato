using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.NumericalSize.Service;
using ThePatho.Features.Global.NumericalSize.DTO;

namespace ThePatho.Features.Global.NumericalSize.Commands
{
    public class GetNumericalSizeCommandHandler : IRequestHandler<GetNumericalSizeCommand, ApiResponse<NumericalSizeItemDto>>
    {
        private readonly INumericalSizeService numericalSizeService;

        public GetNumericalSizeCommandHandler(INumericalSizeService _numericalSizeService)
        {
            numericalSizeService = _numericalSizeService;
        }

        public async Task<ApiResponse<NumericalSizeItemDto>> Handle(GetNumericalSizeCommand request, CancellationToken cancellationToken)
        {
            return await numericalSizeService.GetNumericalSize(request);
        }
    }
}
