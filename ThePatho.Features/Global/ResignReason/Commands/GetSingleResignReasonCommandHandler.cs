using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ResignReason.Service;
using ThePatho.Features.Global.ResignReason.DTO;

namespace ThePatho.Features.Global.ResignReason.Commands
{
    public class GetSingleResignReasonCommandHandler : IRequestHandler<GetSingleResignReasonCommand, ApiResponse<ResignReasonDto>>
    {
        private readonly IResignReasonService Service;

        public GetSingleResignReasonCommandHandler(IResignReasonService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<ResignReasonDto>> Handle(GetSingleResignReasonCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleResignReason(request);
        }
    }
}
