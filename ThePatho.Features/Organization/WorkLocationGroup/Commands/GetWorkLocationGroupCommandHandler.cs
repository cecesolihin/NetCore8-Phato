using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocationGroup.Service;
using ThePatho.Features.Organization.WorkLocationGroup.DTO;

namespace ThePatho.Features.Organization.WorkLocationGroup.Commands
{
    public class GetWorkLocationGroupCommandHandler : IRequestHandler<GetWorkLocationGroupCommand, ApiResponse<WorkLocationGroupItemDto>>
    {
        private readonly IWorkLocationGroupService Service;

        public GetWorkLocationGroupCommandHandler(IWorkLocationGroupService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<WorkLocationGroupItemDto>> Handle(GetWorkLocationGroupCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetWorkLocationGroup(request);
        }
    }
}
