using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.User
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, NewApiResponse<UserItemDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetUserCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<NewApiResponse<UserItemDto>> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetUserList(request);

        }
    }
}
