using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ResignReason.Service;
using ThePatho.Features.Global.ResignReason.DTO;

namespace ThePatho.Features.Global.ResignReason.Commands
{
    public class GetResignReasonCommandHandler : IRequestHandler<GetResignReasonCommand, ApiResponse<ResignReasonItemDto>>
    {
        private readonly IResignReasonService resignReasonService;

        public GetResignReasonCommandHandler(IResignReasonService _resignReasonService)
        {
            resignReasonService = _resignReasonService;
        }

        public async Task<ApiResponse<ResignReasonItemDto>> Handle(GetResignReasonCommand request, CancellationToken cancellationToken)
        {
            return await resignReasonService.GetResignReason(request);
        }
    }
}
