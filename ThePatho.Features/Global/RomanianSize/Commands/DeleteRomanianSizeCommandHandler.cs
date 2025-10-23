using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RomanianSize.Service;

namespace ThePatho.Features.Global.RomanianSize.Commands
{
    public class DeleteRomanianSizeCommandHandler : IRequestHandler<DeleteRomanianSizeCommand, ApiResponse>
    {
        private readonly IRomanianSizeService romanianSizeService;

        public DeleteRomanianSizeCommandHandler(IRomanianSizeService _romanianSizeService)
        {
            romanianSizeService = _romanianSizeService;
        }

        public async Task<ApiResponse> Handle(DeleteRomanianSizeCommand request, CancellationToken cancellationToken)
        {
            return await romanianSizeService.DeleteRomanianSize(request);
        }
    }
}
