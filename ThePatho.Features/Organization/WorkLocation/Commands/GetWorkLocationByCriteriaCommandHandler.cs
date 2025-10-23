using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocation.Service;
using ThePatho.Features.Organization.WorkLocation.DTO;

namespace ThePatho.Features.Organization.WorkLocation.Commands
{
    public class GetWorkLocationByCriteriaCommandHandler : IRequestHandler<GetWorkLocationByCriteriaCommand, ApiResponse<WorkLocationItemDto>>
    {
        private readonly IWorkLocationService Service;

        public GetWorkLocationByCriteriaCommandHandler(IWorkLocationService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<WorkLocationItemDto>> Handle(GetWorkLocationByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetWorkLocationByCriteria(request);
        }
    }
}
