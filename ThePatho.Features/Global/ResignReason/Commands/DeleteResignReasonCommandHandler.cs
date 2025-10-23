using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ResignReason.Service;

namespace ThePatho.Features.Global.ResignReason.Commands
{
    public class DeleteResignReasonCommandHandler : IRequestHandler<DeleteResignReasonCommand, ApiResponse>
    {
        private readonly IResignReasonService resignReasonService;

        public DeleteResignReasonCommandHandler(IResignReasonService _resignReasonService)
        {
            resignReasonService = _resignReasonService;
        }

        public async Task<ApiResponse> Handle(DeleteResignReasonCommand request, CancellationToken cancellationToken)
        {
            return await resignReasonService.DeleteResignReason(request);
        }
    }
}
