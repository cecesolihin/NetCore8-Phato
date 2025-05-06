using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.User
{
    public class GetUserByCriteriaCommandHandler : IRequestHandler<GetUserByCriteriaCommand, ApiResponse<UserDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetUserByCriteriaCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<ApiResponse<UserDto>> Handle(GetUserByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetUserByCriteria(request);

        }
    }
}
