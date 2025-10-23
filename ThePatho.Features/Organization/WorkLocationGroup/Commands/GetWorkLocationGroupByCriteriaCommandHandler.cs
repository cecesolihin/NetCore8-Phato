using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocationGroup.Service;
using ThePatho.Features.Organization.WorkLocationGroup.DTO;

namespace ThePatho.Features.Organization.WorkLocationGroup.Commands
{
    public class GetWorkLocationGroupByCriteriaCommandHandler : IRequestHandler<GetWorkLocationGroupByCriteriaCommand, ApiResponse<WorkLocationGroupItemDto>>
    {
        private readonly IWorkLocationGroupService Service;

        public GetWorkLocationGroupByCriteriaCommandHandler(IWorkLocationGroupService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<WorkLocationGroupItemDto>> Handle(GetWorkLocationGroupByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetWorkLocationGroupByCriteria(request);
        }
    }
}
