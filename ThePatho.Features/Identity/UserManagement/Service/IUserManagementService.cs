using ThePatho.Features.ConfigurationExtensions;
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
        Task<NewApiResponse<UserItemDto>> GetUserList(GetUserCommand request);
        Task<NewApiResponse<UserDto>> GetUserByCriteria(GetUserByCriteriaCommand request);
        #endregion

        #region [Group]
        Task<NewApiResponse<GroupItemDto>> GetGroupList(GetGroupCommand request);
        Task<NewApiResponse<GroupDto>> GetGroupByCriteria(GetGroupByCriteriaCommand request);
        #endregion

        #region [Role]
        Task<NewApiResponse<RoleItemDto>> GetRoleList(GetRoleCommand request);
        Task<NewApiResponse<RoleItemDto>> GetRoleByCriteria(GetRoleByCriteriaCommand request);
        #endregion

        #region [Group Role]
        Task<NewApiResponse<GroupRoleItemDto>> GetGroupRoleList(GetGroupRoleCommand request);
        Task<NewApiResponse<GroupRoleItemDto>> GetGroupRoleByCriteria(GetGroupRoleByCriteriaCommand request);
        #endregion

        #region [User Group]
        Task<NewApiResponse<UserGroupItemDto>> GetUserGroupList(GetUserGroupCommand request);
        Task<NewApiResponse<UserGroupItemDto>> GetUserGroupByCriteria(GetUserGroupByCriteriaCommand request);
        #endregion
    }
}
