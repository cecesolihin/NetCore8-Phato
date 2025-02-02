using MediatR;
using System;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.MPP.Service;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class DeleteMPPCommandHandler : IRequestHandler<DeleteMPPCommand, ApiResponse>
    {
        private readonly IMPPService MPPService;

        public DeleteMPPCommandHandler(IMPPService _MPPService)
        {
            MPPService = _MPPService;
        }

        public async Task<ApiResponse> Handle(DeleteMPPCommand request, CancellationToken cancellationToken)
        {
           
           return await MPPService.DeleteMPP(request);  
        }
    }
}
