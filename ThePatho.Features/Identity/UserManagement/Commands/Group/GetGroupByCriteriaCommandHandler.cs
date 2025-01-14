﻿using MediatR;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Features.Identity.UserManagement.Service;

namespace ThePatho.Features.Identity.UserManagement.Commands.Group
{
    public class GetGroupByCriteriaCommandHandler : IRequestHandler<GetGroupByCriteriaCommand, GroupDto>
    {
        private readonly IUserManagementService userManagementService;
        public GetGroupByCriteriaCommandHandler(IUserManagementService _userManagementService)
        {
            userManagementService = _userManagementService;
        }
        public async Task<GroupDto> Handle(GetGroupByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await userManagementService.GetGroupByCriteria(request);

            return data;
        }
    }
}
