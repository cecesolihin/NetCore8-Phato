using MediatR;
using ThePatho.Features.Recruitment.MPP.DTO;
using ThePatho.Features.Recruitment.MPP.Service;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class GetMPPByCriteriaCommandHandler : IRequestHandler<GetMPPByCriteriaCommand, MPPDto>
    {
        private readonly IMPPService MPPService;
        public GetMPPByCriteriaCommandHandler(IMPPService _MPPService)
        {
            MPPService = _MPPService;
        }
        public async Task<MPPDto> Handle(GetMPPByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await MPPService.GetMPPByCriteria(request);

            return data;
        }
    }
}
