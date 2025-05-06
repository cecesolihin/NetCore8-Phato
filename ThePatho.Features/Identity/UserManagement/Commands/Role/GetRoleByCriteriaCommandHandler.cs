using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.Role
{
    public class GetRoleByCriteriaCommandHandler : IRequestHandler<GetRoleByCriteriaCommand, ApiResponse<RoleItemDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetRoleByCriteriaCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<ApiResponse<RoleItemDto>> Handle(GetRoleByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetRoleByCriteria(request);

        }
    }
}
