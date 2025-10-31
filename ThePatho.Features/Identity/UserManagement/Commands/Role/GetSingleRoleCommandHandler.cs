using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Identity.UserManagement.Commands.Role
{
    public class GetSingleRoleCommandHandler : IRequestHandler<GetSingleRoleCommand, ApiResponse<RoleDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetSingleRoleCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<ApiResponse<RoleDto>> Handle(GetSingleRoleCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetSingleRole(request);

        }
    }
}
