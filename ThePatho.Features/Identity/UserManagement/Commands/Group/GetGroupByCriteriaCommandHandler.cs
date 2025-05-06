using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.Group
{
    public class GetGroupByCriteriaCommandHandler : IRequestHandler<GetGroupByCriteriaCommand, ApiResponse<GroupDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetGroupByCriteriaCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<ApiResponse<GroupDto>> Handle(GetGroupByCriteriaCommand request, CancellationToken cancellationToken)
        {
           return await userManagementService.GetGroupByCriteria(request);

        }
    }
}
