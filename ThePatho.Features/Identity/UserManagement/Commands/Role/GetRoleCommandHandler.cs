using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.Role
{
    public class GetRoleCommandHandler : IRequestHandler<GetRoleCommand, ApiResponse<RoleItemDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetRoleCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<ApiResponse<RoleItemDto>> Handle(GetRoleCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetRoleList(request);

        }
    }
}
