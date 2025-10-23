using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.TerminationType.Service;
using ThePatho.Features.Organization.TerminationType.DTO;

namespace ThePatho.Features.Organization.TerminationType.Commands
{
    public class GetTerminationTypeCommandHandler : IRequestHandler<GetTerminationTypeCommand, ApiResponse<TerminationTypeItemDto>>
    {
        private readonly ITerminationTypeService Service;

        public GetTerminationTypeCommandHandler(ITerminationTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<TerminationTypeItemDto>> Handle(GetTerminationTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetTerminationType(request);
        }
    }
}
