using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.TerminationType.Service;

namespace ThePatho.Features.Organization.TerminationType.Commands
{
    public class DeleteTerminationTypeCommandHandler : IRequestHandler<DeleteTerminationTypeCommand, ApiResponse>
    {
        private readonly ITerminationTypeService Service;

        public DeleteTerminationTypeCommandHandler(ITerminationTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(DeleteTerminationTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteTerminationType(request);
        }
    }
}
