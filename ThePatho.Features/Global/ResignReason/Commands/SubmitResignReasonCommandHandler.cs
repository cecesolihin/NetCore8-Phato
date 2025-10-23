using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ResignReason.Service;

namespace ThePatho.Features.Global.ResignReason.Commands
{
    public class SubmitResignReasonCommandHandler : IRequestHandler<SubmitResignReasonCommand, ApiResponse>
    {
        private readonly IResignReasonService resignReasonService;

        public SubmitResignReasonCommandHandler(IResignReasonService _resignReasonService)
        {
            resignReasonService = _resignReasonService;
        }

        public async Task<ApiResponse> Handle(SubmitResignReasonCommand request, CancellationToken cancellationToken)
        {
            return await resignReasonService.SubmitResignReason(request);
        }
    }
}
