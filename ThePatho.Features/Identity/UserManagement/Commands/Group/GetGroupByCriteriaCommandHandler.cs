using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.Group
{
    public class GetGroupByCriteriaCommandHandler : IRequestHandler<GetGroupByCriteriaCommand, NewApiResponse<GroupDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetGroupByCriteriaCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<NewApiResponse<GroupDto>> Handle(GetGroupByCriteriaCommand request, CancellationToken cancellationToken)
        {
           return await userManagementService.GetGroupByCriteria(request);

        }
    }
}
