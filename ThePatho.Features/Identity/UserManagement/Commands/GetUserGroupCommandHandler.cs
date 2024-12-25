using MediatR;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands
{
    public class GetUserGroupCommandHandler : IRequestHandler<GetUserGroupCommand, UserGroupItemDto>
    {
        private readonly IUserManagementService userManagementService;
        public GetUserGroupCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<UserGroupItemDto> Handle(GetUserGroupCommand request, CancellationToken cancellationToken)
        {
            var data = await userManagementService.GetUserGroupList(request);

            return new UserGroupItemDto()
            {
                DataOfRecords = data.Count,
                UserGroupList = data,
            };
        }
    }
}
