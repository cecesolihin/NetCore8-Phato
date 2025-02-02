using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.UserGroup
{
    public class GetUserGroupByCriteriaCommandHandler : IRequestHandler<GetUserGroupByCriteriaCommand, NewApiResponse<UserGroupItemDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetUserGroupByCriteriaCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<NewApiResponse<UserGroupItemDto>> Handle(GetUserGroupByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetUserGroupByCriteria(request);

        }
    }
}
