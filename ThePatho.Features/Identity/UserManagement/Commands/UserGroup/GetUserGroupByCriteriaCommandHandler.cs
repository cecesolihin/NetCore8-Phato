using MediatR;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.UserGroup
{
    public class GetUserGroupByCriteriaCommandHandler : IRequestHandler<GetUserGroupByCriteriaCommand, UserGroupItemDto>
    {
        private readonly IUserManagementService userManagementService;
        public GetUserGroupByCriteriaCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<UserGroupItemDto> Handle(GetUserGroupByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await userManagementService.GetUserGroupByCriteria(request);

            return new UserGroupItemDto()
            {
                DataOfRecords = data.Count,
                UserGroupList = data,
            };
        }
    }
}
