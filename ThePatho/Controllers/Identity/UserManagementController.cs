using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.Commands.Group;
using ThePatho.Features.Identity.UserManagement.Commands.GroupRole;
using ThePatho.Features.Identity.UserManagement.Commands.Role;
using ThePatho.Features.Identity.UserManagement.Commands.User;
using ThePatho.Features.Identity.UserManagement.Commands.UserGroup;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Controllers.Identity
{
    [ApiController]
    [Route(ApiRoutes.IdentityMenu.UserManagement)]
    [ApiExplorerSettings(GroupName = "Identity")]
    [Authorize]
    public class UserManagementController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserManagementController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private static IActionResult ApiResult<TResponse>(TResponse response) where TResponse : ApiResponse
        {
            return new ApiResult<TResponse>(response);
        }

        #region [USER]
        [HttpPost(ApiRoutes.Methods.GetUserList)]
        public async Task<IActionResult> GetUserList([FromBody] GetUserCommand command,
           CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.GetUserByCriteria)]
        public async Task<IActionResult> GetUserByCriteria([FromBody] GetUserByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
        #endregion

        #region [ROLE]
        [HttpPost(ApiRoutes.Methods.GetRoleList)]
        public async Task<IActionResult> GetRoleList([FromBody] GetRoleCommand command,
           CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.GetRoleByCriteria)]
        public async Task<IActionResult> GetRoleByCriteria([FromBody] GetRoleByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
        #endregion

        #region [GROUP]
        [HttpPost(ApiRoutes.Methods.GetGroupList)]
        public async Task<IActionResult> GetGroupList([FromBody] GetGroupCommand command,
          CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.GetGroupByCriteria)]
        public async Task<IActionResult> GetGroupByCriteria([FromBody] GetGroupByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
        #endregion

        #region [GROUP ROLE]
        [HttpPost(ApiRoutes.Methods.GetGroupRoleList)]
        public async Task<IActionResult> GetGroupRoleList([FromBody] GetGroupRoleCommand command,
          CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.GetGroupRoleByCriteria)]
        public async Task<IActionResult> GetGroupRoleByCriteria([FromBody] GetGroupRoleByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
        #endregion

        #region [USER GROUP]
        [HttpPost(ApiRoutes.Methods.GetUserGroupList)]
        public async Task<IActionResult> GetUserGroupList([FromBody] GetUserGroupCommand command,
          CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }

        [HttpPost(ApiRoutes.Methods.GetUserGroupByCriteria)]
        public async Task<IActionResult> GetUserGroupByCriteria([FromBody] GetUserGroupByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return ApiResult(result);
        }
        #endregion
    }
}
