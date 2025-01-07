using MediatR;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.User
{
    public class GetUserByCriteriaCommandHandler : IRequestHandler<GetUserByCriteriaCommand, UserDto>
    {
        private readonly IUserManagementService userManagementService;
        public GetUserByCriteriaCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<UserDto> Handle(GetUserByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await userManagementService.GetUserByCriteria(request);

            return data;
        }
    }
}
