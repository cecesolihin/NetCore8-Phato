using MediatR;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands
{
    public class GetGroupRoleByCriteriaCommandHandler : IRequestHandler<GetGroupRoleByCriteriaCommand, GroupRoleItemDto>
    {
        private readonly IUserManagementService userManagementService;
        public GetGroupRoleByCriteriaCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<GroupRoleItemDto> Handle(GetGroupRoleByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await userManagementService.GetGroupRoleByCriteria(request);

            return new GroupRoleItemDto()
            {
                DataOfRecords = data.Count,
                GroupRoleList = data,
            };
        }
    }
}
