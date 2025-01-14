using MediatR;
using ThePatho.Features.Recruitment.MPP.DTO;
using ThePatho.Features.Recruitment.MPP.Service;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class GetMPPCommandHandler : IRequestHandler<GetMPPCommand, MPPItemDto>
    {
        private readonly IMPPService MPPService;
        public GetMPPCommandHandler(IMPPService _MPPService)
        {
            MPPService =_MPPService;
        }
        public async Task<MPPItemDto> Handle(GetMPPCommand request, CancellationToken cancellationToken)
        {
            var data = await MPPService.GetMPP(request);

            return new MPPItemDto
            {
                DataOfRecords = data.Count,
                MPPList = data,
            };
        }
    }
}
