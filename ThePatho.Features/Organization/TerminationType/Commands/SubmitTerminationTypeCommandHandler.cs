using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.TerminationType.Service;

namespace ThePatho.Features.Organization.TerminationType.Commands
{
    public class SubmitTerminationTypeCommandHandler : IRequestHandler<SubmitTerminationTypeCommand, ApiResponse>
    {
        private readonly ITerminationTypeService Service;

        public SubmitTerminationTypeCommandHandler(ITerminationTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(SubmitTerminationTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitTerminationType(request);
        }
    }
}
