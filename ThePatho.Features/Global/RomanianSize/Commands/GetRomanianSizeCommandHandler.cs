using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RomanianSize.Service;
using ThePatho.Features.Global.RomanianSize.DTO;

namespace ThePatho.Features.Global.RomanianSize.Commands
{
    public class GetRomanianSizeCommandHandler : IRequestHandler<GetRomanianSizeCommand, ApiResponse<RomanianSizeItemDto>>
    {
        private readonly IRomanianSizeService romanianSizeService;

        public GetRomanianSizeCommandHandler(IRomanianSizeService _romanianSizeService)
        {
            romanianSizeService = _romanianSizeService;
        }

        public async Task<ApiResponse<RomanianSizeItemDto>> Handle(GetRomanianSizeCommand request, CancellationToken cancellationToken)
        {
            return await romanianSizeService.GetRomanianSize(request);
        }
    }
}
