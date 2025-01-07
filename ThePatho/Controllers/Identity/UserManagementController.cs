using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThePatho.Features.ConfigurationExtensions;
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
    public class UserManagementController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserManagementController(IMediator _mediator)
        {
            mediator = _mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        #region [USER]
        [HttpPost(ApiRoutes.Methods.GetUserList)]
        public async Task<IActionResult> GetUserList([FromBody] GetUserCommand command,
           CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<UserDto>>(HttpStatusCode.OK, result.UserList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<UserDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetUserByCriteria)]
        public async Task<IActionResult> GetUserByCriteria([FromBody] GetUserByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<UserDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<UserDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        #endregion

        #region [ROLE]
        [HttpPost(ApiRoutes.Methods.GetRoleList)]
        public async Task<IActionResult> GetRoleList([FromBody] GetRoleCommand command,
           CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<RoleDto>>(HttpStatusCode.OK, result.RoleList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<RoleDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetRoleByCriteria)]
        public async Task<IActionResult> GetRoleByCriteria([FromBody] GetRoleByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<RoleDto>>(HttpStatusCode.OK, result.RoleList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<RoleDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        #endregion

        #region [GROUP]
        [HttpPost(ApiRoutes.Methods.GetGroupList)]
        public async Task<IActionResult> GetGroupList([FromBody] GetGroupCommand command,
          CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<GroupDto>>(HttpStatusCode.OK, result.GroupList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<GroupDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetGroupByCriteria)]
        public async Task<IActionResult> GetGroupByCriteria([FromBody] GetGroupByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<GroupDto>(HttpStatusCode.OK, result, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<GroupDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        #endregion

        #region [GROUP ROLE]
        [HttpPost(ApiRoutes.Methods.GetGroupRoleList)]
        public async Task<IActionResult> GetGroupRoleList([FromBody] GetGroupRoleCommand command,
          CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<GroupRoleDto>>(HttpStatusCode.OK, result.GroupRoleList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<GroupRoleDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetGroupRoleByCriteria)]
        public async Task<IActionResult> GetGroupRoleByCriteria([FromBody] GetGroupRoleByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<GroupRoleDto>>(HttpStatusCode.OK, result.GroupRoleList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<GroupRoleDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        #endregion

        #region [USER GROUP]
        [HttpPost(ApiRoutes.Methods.GetUserGroupList)]
        public async Task<IActionResult> GetUserGroupList([FromBody] GetUserGroupCommand command,
          CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<UserGroupDto>>(HttpStatusCode.OK, result.UserGroupList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<UserGroupDto>>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost(ApiRoutes.Methods.GetUserGroupByCriteria)]
        public async Task<IActionResult> GetUserGroupByCriteria([FromBody] GetUserGroupByCriteriaCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);

                var response = new ApiResponse<List<UserGroupDto>>(HttpStatusCode.OK, result.UserGroupList, "Process Successed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<UserGroupDto>(HttpStatusCode.InternalServerError, null, "Internal Server Error", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        #endregion
    }
}
