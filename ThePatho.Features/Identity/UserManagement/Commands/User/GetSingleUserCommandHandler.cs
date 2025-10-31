using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Identity.UserManagement.Commands.User
{
    public class GetSingleUserCommandHandler : IRequestHandler<GetSingleUserCommand, ApiResponse<UserDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetSingleUserCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<ApiResponse<UserDto>> Handle(GetSingleUserCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetSingleUser(request);

        }
    }
}
