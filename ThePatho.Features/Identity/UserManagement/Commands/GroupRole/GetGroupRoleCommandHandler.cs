using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.GroupRole
{
    public class GetGroupRoleCommandHandler : IRequestHandler<GetGroupRoleCommand, NewApiResponse<GroupRoleItemDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetGroupRoleCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<NewApiResponse<GroupRoleItemDto>> Handle(GetGroupRoleCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetGroupRoleList(request);

        }
    }
}
