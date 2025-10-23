using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RomanianSize.Service;
using ThePatho.Features.Global.RomanianSize.DTO;

namespace ThePatho.Features.Global.RomanianSize.Commands
{
    public class GetSingleRomanianSizeCommandHandler : IRequestHandler<GetSingleRomanianSizeCommand, ApiResponse<RomanianSizeDto>>
    {
        private readonly IRomanianSizeService Service;

        public GetSingleRomanianSizeCommandHandler(IRomanianSizeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<RomanianSizeDto>> Handle(GetSingleRomanianSizeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleRomanianSize(request);
        }
    }
}
