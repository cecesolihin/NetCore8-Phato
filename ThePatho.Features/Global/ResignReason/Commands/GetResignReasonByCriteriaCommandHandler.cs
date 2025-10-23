using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ResignReason.Service;
using ThePatho.Features.Global.ResignReason.DTO;

namespace ThePatho.Features.Global.ResignReason.Commands
{
    public class GetResignReasonByCriteriaCommandHandler : IRequestHandler<GetResignReasonByCriteriaCommand, ApiResponse<ResignReasonItemDto>>
    {
        private readonly IResignReasonService resignReasonService;

        public GetResignReasonByCriteriaCommandHandler(IResignReasonService _resignReasonService)
        {
            resignReasonService = _resignReasonService;
        }

        public async Task<ApiResponse<ResignReasonItemDto>> Handle(GetResignReasonByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await resignReasonService.GetResignReasonByCriteria(request);
        }
    }
}
