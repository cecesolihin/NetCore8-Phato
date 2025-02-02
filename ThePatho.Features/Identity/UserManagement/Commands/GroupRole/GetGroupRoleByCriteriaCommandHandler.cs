using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.GroupRole
{
    public class GetGroupRoleByCriteriaCommandHandler : IRequestHandler<GetGroupRoleByCriteriaCommand, NewApiResponse<GroupRoleItemDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetGroupRoleByCriteriaCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<NewApiResponse<GroupRoleItemDto>> Handle(GetGroupRoleByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetGroupRoleByCriteria(request);

        }
    }
}
