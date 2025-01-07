using MediatR;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.Role
{
    public class GetRoleCommandHandler : IRequestHandler<GetRoleCommand, RoleItemDto>
    {
        private readonly IUserManagementService userManagementService;
        public GetRoleCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<RoleItemDto> Handle(GetRoleCommand request, CancellationToken cancellationToken)
        {
            var data = await userManagementService.GetRoleList(request);

            return new RoleItemDto()
            {
                DataOfRecords = data.Count,
                RoleList = data,
            };
        }
    }
}
