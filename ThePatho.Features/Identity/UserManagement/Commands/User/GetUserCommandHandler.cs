using MediatR;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.User
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, UserItemDto>
    {
        private readonly IUserManagementService userManagementService;
        public GetUserCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<UserItemDto> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            var data = await userManagementService.GetUserList(request);

            return new UserItemDto()
            {
                DataOfRecords = data.Count,
                UserList = data,
            };
        }
    }
}
