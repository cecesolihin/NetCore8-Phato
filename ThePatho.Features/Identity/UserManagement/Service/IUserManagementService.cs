
using ThePatho.Features.Identity.UserManagement.Commands;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Service
{
    public interface IUserManagementService
    {
        #region [User]
        Task<List<UserDto>> GetUserList(GetUserCommand request);
        Task<UserDto> GetUserByCriteria(GetUserByCriteriaCommand request);
        #endregion

        #region [Group]
        Task<List<GroupDto>> GetGroupList(GetGroupCommand request);
        Task<GroupDto> GetGroupByCriteria(GetGroupByCriteriaCommand request);
        #endregion

        #region [Role]
        Task<List<RoleDto>> GetRoleList(GetRoleCommand request);
        Task<List<RoleDto>> GetRoleByCriteria(GetRoleByCriteriaCommand request);
        #endregion

        #region [Group Role]
        Task<List<GroupRoleDto>> GetGroupRoleList(GetGroupRoleCommand request);
        Task<List<GroupRoleDto>> GetGroupRoleByCriteria(GetGroupRoleByCriteriaCommand request);
        #endregion

        #region [User Group]
        Task<List<UserGroupDto>> GetUserGroupList(GetUserGroupCommand request);
        Task<List<UserGroupDto>> GetUserGroupByCriteria(GetUserGroupByCriteriaCommand request);
        #endregion
    }
}
