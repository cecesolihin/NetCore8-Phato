using MediatR;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands
{
    public class GetGroupCommandHandler : IRequestHandler<GetGroupCommand, GroupItemDto>
    {
        private readonly IUserManagementService userManagementService;
        public GetGroupCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<GroupItemDto> Handle(GetGroupCommand request, CancellationToken cancellationToken)
        {
            var data = await userManagementService.GetGroupList(request);

            return new GroupItemDto()
            {
                DataOfRecords = data.Count,
                GroupList = data,
            };
        }
    }
}
