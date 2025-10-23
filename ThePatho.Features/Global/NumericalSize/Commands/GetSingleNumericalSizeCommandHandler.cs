using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.NumericalSize.Service;
using ThePatho.Features.Global.NumericalSize.DTO;

namespace ThePatho.Features.Global.NumericalSize.Commands
{
    public class GetSingleNumericalSizeCommandHandler : IRequestHandler<GetSingleNumericalSizeCommand, ApiResponse<NumericalSizeDto>>
    {
        private readonly INumericalSizeService Service;

        public GetSingleNumericalSizeCommandHandler(INumericalSizeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<NumericalSizeDto>> Handle(GetSingleNumericalSizeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleNumericalSize(request);
        }
    }
}
