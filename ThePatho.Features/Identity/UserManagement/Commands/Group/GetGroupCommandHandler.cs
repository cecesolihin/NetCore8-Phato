﻿using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.Group
{
    public class GetGroupCommandHandler : IRequestHandler<GetGroupCommand, NewApiResponse<GroupItemDto>>
    {
        private readonly IUserManagementService userManagementService;
        public GetGroupCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<NewApiResponse<GroupItemDto>> Handle(GetGroupCommand request, CancellationToken cancellationToken)
        {
            return await userManagementService.GetGroupList(request);

        }
    }
}
