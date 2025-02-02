using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.MPP.DTO;
using ThePatho.Features.Recruitment.MPP.Service;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class GetMPPByCriteriaCommandHandler : IRequestHandler<GetMPPByCriteriaCommand, NewApiResponse<MPPDto>>
    {
        private readonly IMPPService MPPService;
        public GetMPPByCriteriaCommandHandler(IMPPService _MPPService)
        {
            MPPService = _MPPService;
        }
        public async Task<NewApiResponse<MPPDto>> Handle(GetMPPByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await MPPService.GetMPPByCriteria(request);

        }
    }
}
