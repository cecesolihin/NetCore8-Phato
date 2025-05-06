using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.UserGroup
{
    public class GetUserGroupCommandHandler : IRequestHandler<GetUserGroupCommand, ApiResponse<UserGroupItemDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetUserGroupCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<ApiResponse<UserGroupItemDto>> Handle(GetUserGroupCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetUserGroupList(request);

        }
    }
}
