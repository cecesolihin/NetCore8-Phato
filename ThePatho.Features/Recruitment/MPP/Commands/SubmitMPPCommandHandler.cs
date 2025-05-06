using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.MPP.Service;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class SubmitMPPCommandHandler : IRequestHandler<SubmitMPPCommand, ApiResponse>
    {
        private readonly IMPPService MPPService;

        public SubmitMPPCommandHandler(IMPPService _MPPService)
        {
            MPPService = _MPPService;
        }

        public async Task<ApiResponse> Handle(SubmitMPPCommand request, CancellationToken cancellationToken)
        {
           return await MPPService.SubmitMPP(request);
        }
    }
}
