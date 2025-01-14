using MediatR;
using ThePatho.Features.Recruitment.MPP.Service;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class SubmitMPPCommandHandler : IRequestHandler<SubmitMPPCommand, string>
    {
        private readonly IMPPService MPPService;

        public SubmitMPPCommandHandler(IMPPService _MPPService)
        {
            MPPService = _MPPService;
        }

        public async Task<string> Handle(SubmitMPPCommand request, CancellationToken cancellationToken)
        {
            await MPPService.SubmitMPP(request);
            if (request.Action == "ADD")
            {
                return "MPP successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "MPP successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
