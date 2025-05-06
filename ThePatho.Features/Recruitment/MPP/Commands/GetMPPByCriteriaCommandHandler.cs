using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.MPP.DTO;
using ThePatho.Features.Recruitment.MPP.Service;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class GetMPPByCriteriaCommandHandler : IRequestHandler<GetMPPByCriteriaCommand, ApiResponse<MPPDto>>
    {
        private readonly IMPPService MPPService;
        public GetMPPByCriteriaCommandHandler(IMPPService _MPPService)
        {
            MPPService = _MPPService;
        }
        public async Task<ApiResponse<MPPDto>> Handle(GetMPPByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await MPPService.GetMPPByCriteria(request);

        }
    }
}
