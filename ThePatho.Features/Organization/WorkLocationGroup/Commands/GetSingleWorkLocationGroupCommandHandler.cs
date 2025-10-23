using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocationGroup.Service;
using ThePatho.Features.Organization.WorkLocationGroup.DTO;

namespace ThePatho.Features.Organization.WorkLocationGroup.Commands
{
    public class GetSingleWorkLocationGroupCommandHandler : IRequestHandler<GetSingleWorkLocationGroupCommand, ApiResponse<WorkLocationGroupDto>>
    {
        private readonly IWorkLocationGroupService Service;

        public GetSingleWorkLocationGroupCommandHandler(IWorkLocationGroupService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<WorkLocationGroupDto>> Handle(GetSingleWorkLocationGroupCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleWorkLocationGroup(request);
        }
    }
}
