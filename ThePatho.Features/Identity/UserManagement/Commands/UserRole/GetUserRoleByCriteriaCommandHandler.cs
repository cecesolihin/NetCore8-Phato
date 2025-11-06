using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.UserRole
{
    public class GetUserRoleByCriteriaCommandHandler : IRequestHandler<GetUserRoleByCriteriaCommand, ApiResponse<UserRoleItemDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetUserRoleByCriteriaCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<ApiResponse<UserRoleItemDto>> Handle(GetUserRoleByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetUserRoleByCriteria(request);

        }
    }
}
