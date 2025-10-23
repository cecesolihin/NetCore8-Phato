using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RomanianSize.Service;

namespace ThePatho.Features.Global.RomanianSize.Commands
{
    public class SubmitRomanianSizeCommandHandler : IRequestHandler<SubmitRomanianSizeCommand, ApiResponse>
    {
        private readonly IRomanianSizeService romanianSizeService;

        public SubmitRomanianSizeCommandHandler(IRomanianSizeService _romanianSizeService)
        {
            romanianSizeService = _romanianSizeService;
        }

        public async Task<ApiResponse> Handle(SubmitRomanianSizeCommand request, CancellationToken cancellationToken)
        {
            return await romanianSizeService.SubmitRomanianSize(request);
        }
    }
}
