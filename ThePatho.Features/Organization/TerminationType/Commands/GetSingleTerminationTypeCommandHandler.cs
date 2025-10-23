using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.TerminationType.Service;
using ThePatho.Features.Organization.TerminationType.DTO;

namespace ThePatho.Features.Organization.TerminationType.Commands
{
    public class GetSingleTerminationTypeCommandHandler : IRequestHandler<GetSingleTerminationTypeCommand, ApiResponse<TerminationTypeDto>>
    {
        private readonly ITerminationTypeService Service;

        public GetSingleTerminationTypeCommandHandler(ITerminationTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<TerminationTypeDto>> Handle(GetSingleTerminationTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleTerminationType(request);
        }
    }
}
