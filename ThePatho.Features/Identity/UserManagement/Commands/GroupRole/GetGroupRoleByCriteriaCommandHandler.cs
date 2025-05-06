using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.GroupRole
{
    public class GetGroupRoleByCriteriaCommandHandler : IRequestHandler<GetGroupRoleByCriteriaCommand, ApiResponse<GroupRoleItemDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetGroupRoleByCriteriaCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<ApiResponse<GroupRoleItemDto>> Handle(GetGroupRoleByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetGroupRoleByCriteria(request);

        }
    }
}
