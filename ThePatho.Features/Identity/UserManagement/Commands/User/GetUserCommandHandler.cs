using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.User
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, ApiResponse<UserItemDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetUserCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<ApiResponse<UserItemDto>> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetUserList(request);

        }
    }
}
