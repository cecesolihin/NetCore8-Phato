using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.Group
{
    public class GetGroupCommandHandler : IRequestHandler<GetGroupCommand, ApiResponse<GroupItemDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetGroupCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<ApiResponse<GroupItemDto>> Handle(GetGroupCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetGroupList(request);

        }
    }
}
