using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.GroupRole
{
    public class GetGroupRoleCommandHandler : IRequestHandler<GetGroupRoleCommand, ApiResponse<GroupRoleItemDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetGroupRoleCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<ApiResponse<GroupRoleItemDto>> Handle(GetGroupRoleCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetGroupRoleList(request);

        }
    }
}
