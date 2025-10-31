using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Identity.UserManagement.Commands.Group
{
    public class GetSingleGroupCommandHandler : IRequestHandler<GetSingleGroupCommand, ApiResponse<GroupDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetSingleGroupCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<ApiResponse<GroupDto>> Handle(GetSingleGroupCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetSingleGroup(request);

        }
    }
}
