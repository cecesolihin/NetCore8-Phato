using MediatR;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.GroupRole
{
    public class GetGroupRoleCommandHandler : IRequestHandler<GetGroupRoleCommand, GroupRoleItemDto>
    {
        private readonly IUserManagementService userManagementService;
        public GetGroupRoleCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<GroupRoleItemDto> Handle(GetGroupRoleCommand request, CancellationToken cancellationToken)
        {
            var data = await userManagementService.GetGroupRoleList(request);

            return new GroupRoleItemDto()
            {
                DataOfRecords = data.Count,
                GroupRoleList = data,
            };
        }
    }
}
