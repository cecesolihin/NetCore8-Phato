using MediatR;
using System;
using ThePatho.Features.Recruitment.MPP.Service;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class DeleteMPPCommandHandler : IRequestHandler<DeleteMPPCommand, bool>
    {
        private readonly IMPPService MPPService;

        public DeleteMPPCommandHandler(IMPPService _MPPService)
        {
            MPPService = _MPPService;
        }

        public async Task<bool> Handle(DeleteMPPCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await MPPService.DeleteMPP(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }
}
