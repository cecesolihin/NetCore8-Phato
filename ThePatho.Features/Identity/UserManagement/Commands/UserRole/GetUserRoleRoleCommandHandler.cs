using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.UserRole
{
    public class GetUserRoleRoleCommandHandler : IRequestHandler<GetUserRoleCommand, ApiResponse<UserRoleItemDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetUserRoleRoleCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<ApiResponse<UserRoleItemDto>> Handle(GetUserRoleCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetUserRoleList(request);

        }
    }
}
