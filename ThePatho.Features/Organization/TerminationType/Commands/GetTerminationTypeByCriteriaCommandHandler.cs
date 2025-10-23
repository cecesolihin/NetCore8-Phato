using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.TerminationType.Service;
using ThePatho.Features.Organization.TerminationType.DTO;

namespace ThePatho.Features.Organization.TerminationType.Commands
{
    public class GetTerminationTypeByCriteriaCommandHandler : IRequestHandler<GetTerminationTypeByCriteriaCommand, ApiResponse<TerminationTypeItemDto>>
    {
        private readonly ITerminationTypeService Service;

        public GetTerminationTypeByCriteriaCommandHandler(ITerminationTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<TerminationTypeItemDto>> Handle(GetTerminationTypeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetTerminationTypeByCriteria(request);
        }
    }
}
