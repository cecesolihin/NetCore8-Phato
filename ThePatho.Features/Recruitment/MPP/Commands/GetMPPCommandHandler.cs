using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.MPP.DTO;
using ThePatho.Features.Recruitment.MPP.Service;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class GetMPPCommandHandler : IRequestHandler<GetMPPCommand, NewApiResponse<MPPItemDto>>
    {
        private readonly IMPPService MPPService;
        public GetMPPCommandHandler(IMPPService _MPPService)
        {
            MPPService =_MPPService;
        }
        public async Task<NewApiResponse<MPPItemDto>> Handle(GetMPPCommand request, CancellationToken cancellationToken)
        {
            return await MPPService.GetMPP(request);
        }
    }
}
