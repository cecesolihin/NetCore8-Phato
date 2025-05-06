using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.Commands.Group;
using ThePatho.Features.Identity.UserManagement.Commands.GroupRole;
using ThePatho.Features.Identity.UserManagement.Commands.Role;
using ThePatho.Features.Identity.UserManagement.Commands.User;
using ThePatho.Features.Identity.UserManagement.Commands.UserGroup;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Service
{
    public interface IUserManagementService
    {
        #region [User]
        Task<ApiResponse<UserItemDto>> GetUserList(GetUserCommand request);
        Task<ApiResponse<UserDto>> GetUserByCriteria(GetUserByCriteriaCommand request);
        #endregion

        #region [Group]
        Task<ApiResponse<GroupItemDto>> GetGroupList(GetGroupCommand request);
        Task<ApiResponse<GroupDto>> GetGroupByCriteria(GetGroupByCriteriaCommand request);
        #endregion

        #region [Role]
        Task<ApiResponse<RoleItemDto>> GetRoleList(GetRoleCommand request);
        Task<ApiResponse<RoleItemDto>> GetRoleByCriteria(GetRoleByCriteriaCommand request);
        #endregion

        #region [Group Role]
        Task<ApiResponse<GroupRoleItemDto>> GetGroupRoleList(GetGroupRoleCommand request);
        Task<ApiResponse<GroupRoleItemDto>> GetGroupRoleByCriteria(GetGroupRoleByCriteriaCommand request);
        #endregion

        #region [User Group]
        Task<ApiResponse<UserGroupItemDto>> GetUserGroupList(GetUserGroupCommand request);
        Task<ApiResponse<UserGroupItemDto>> GetUserGroupByCriteria(GetUserGroupByCriteriaCommand request);
        #endregion
    }
}
