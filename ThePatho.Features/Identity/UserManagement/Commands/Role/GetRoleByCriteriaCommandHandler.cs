using MediatR;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.Role
{
    public class GetRoleByCriteriaCommandHandler : IRequestHandler<GetRoleByCriteriaCommand, RoleItemDto>
    {
        private readonly IUserManagementService userManagementService;
        public GetRoleByCriteriaCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<RoleItemDto> Handle(GetRoleByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await userManagementService.GetRoleByCriteria(request);

            return new RoleItemDto()
            {
                DataOfRecords = data.Count,
                RoleList = data,
            };
        }
    }
}
