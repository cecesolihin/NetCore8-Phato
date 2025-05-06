using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.MPP.DTO;
using ThePatho.Features.Recruitment.MPP.Service;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class GetMPPCommandHandler : IRequestHandler<GetMPPCommand, ApiResponse<MPPItemDto>>
    {
        private readonly IMPPService MPPService;
        public GetMPPCommandHandler(IMPPService _MPPService)
        {
            MPPService =_MPPService;
        }
        public async Task<ApiResponse<MPPItemDto>> Handle(GetMPPCommand request, CancellationToken cancellationToken)
        {
            return await MPPService.GetMPP(request);
        }
    }
}
