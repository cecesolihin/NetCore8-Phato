using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Identity.UserManagement.Commands.Group;
using ThePatho.Features.Identity.UserManagement.Commands.GroupRole;
using ThePatho.Features.Identity.UserManagement.Commands.Role;
using ThePatho.Features.Identity.UserManagement.Commands.User;
using ThePatho.Features.Identity.UserManagement.Commands.UserGroup;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Identity.UserManagement.Service
{
    public class UserManagementService : IUserManagementService
    {
        private readonly DapperContext dapperContext;

        public UserManagementService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        #region [User]
        public async Task<List<UserDto>> GetUserList(GetUserCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.Users)
                .Select("user_id AS UserId",
                        "username AS Username",
                        "full_name AS FullName",
                        "email AS Email",
                        "email_confirmed AS EmailConfirmed",
                        "password_hash AS PasswordHash",
                        "phone_number AS PhoneNumber",
                        "phone_number_confirmed AS PhoneNumberConfirmed",
                        "is_active AS IsActive",
                        "is_locked AS IsLocked",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterUserName),
                    q => q.WhereIn("username", request.FilterUserName)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterFullName),
                    q => q.WhereContains("full_name", request.FilterFullName)
                 ).When(
                    !string.IsNullOrWhiteSpace(request.FilterEmail),
                    q => q.WhereContains("email", request.FilterEmail)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterPhone),
                    q => q.WhereContains("phone_number", request.FilterPhone)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<UserDto>(query);
            return results.ToList();
        }
        public async Task<UserDto> GetUserByCriteria(GetUserByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new SqlKata.Query(TableName.Users)
                .Select("user_id AS UserId",
                        "username AS Username",
                        "full_name AS FullName",
                        "email AS Email",
                        "email_confirmed AS EmailConfirmed",
                        "password_hash AS PasswordHash",
                        "phone_number AS PhoneNumber",
                        "phone_number_confirmed AS PhoneNumberConfirmed",
                        "is_active AS IsActive",
                        "is_locked AS IsLocked",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterUserId),
                    q => q.WhereIn("user_id", request.FilterUserId)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterUserName),
                    q => q.WhereContains("username", request.FilterUserName)
                );
            var data = await db.FirstOrDefaultAsync<UserDto>(query);
            return data;
        }
        #endregion

        #region [Group]
        public async Task<List<GroupDto>> GetGroupList(GetGroupCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.Groups)
                .Select("group_id AS GroupId",
                      "group_name AS GroupName",
                      "description AS Description",
                      "is_active AS IsActive",
                      "inserted_by AS InsertedBy",
                      "inserted_date AS InsertedDate",
                      "modified_by AS ModifiedBy",
                      "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterGroup),
                    q => q.WhereContains("group_name", request.FilterGroup)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterDescription),
                    q => q.WhereContains("description", request.FilterDescription)
                );
            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<GroupDto>(query);
            return results.ToList();
        }
        public async Task<GroupDto> GetGroupByCriteria(GetGroupByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.Groups)
                .Select("group_id AS GroupId",
                      "group_name AS GroupName",
                      "description AS Description",
                      "is_active AS IsActive",
                      "inserted_by AS InsertedBy",
                      "inserted_date AS InsertedDate",
                      "modified_by AS ModifiedBy",
                      "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterGroup),
                    q => q.WhereContains("group_name", request.FilterGroup)
                );

            var data = await db.FirstOrDefaultAsync<GroupDto>(query);
            return data;
        }
        #endregion

        #region [Role]
        public async Task<List<RoleDto>> GetRoleList(GetRoleCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.Roles)
                .Select("role_id AS RoleId",
                      "role_name AS RoleName",
                      "description AS Description",
                      "parent_menu_id AS ParentMenuId",
                      "role_label AS RoleLabel",
                      "order_no AS OrderNo",
                      "inserted_by AS InsertedBy",
                      "inserted_date AS InsertedDate",
                      "modified_by AS ModifiedBy",
                      "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterRoleName),
                    q => q.WhereIn("role_name", request.FilterRoleName)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterDescription),
                    q => q.WhereContains("description", request.FilterDescription)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterRoleLabel),
                    q => q.WhereContains("role_label", request.FilterRoleLabel)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<RoleDto>(query);
            return results.ToList();
        }
        public async Task<List<RoleDto>> GetRoleByCriteria(GetRoleByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.Roles)
                .Select("role_id AS RoleId",
                      "role_name AS RoleName",
                      "description AS Description",
                      "parent_menu_id AS ParentMenuId",
                      "role_label AS RoleLabel",
                      "order_no AS OrderNo",
                      "inserted_by AS InsertedBy",
                      "inserted_date AS InsertedDate",
                      "modified_by AS ModifiedBy",
                      "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterRoleName),
                    q => q.WhereIn("role_name", request.FilterRoleName)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterRoleLabel),
                    q => q.WhereContains("role_label", request.FilterRoleLabel)
                );

            var results = await db.GetAsync<RoleDto>(query);
            return results.ToList();
        }
        #endregion

        #region [Group Role]
        public async Task<List<GroupRoleDto>> GetGroupRoleList(GetGroupRoleCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.GroupRoles)
                .Select("group_role_id AS GroupRoleId",
                      "group_id AS GroupId",
                      "role_id AS RoleId",
                      "is_active AS IsActive",
                      "parent_menu_id AS ParentMenuId",
                      "inserted_by AS InsertedBy",
                      "inserted_date AS InsertedDate",
                      "modified_by AS ModifiedBy",
                      "modified_date AS ModifiedDate")
                 .When(
                    !string.IsNullOrWhiteSpace(request.FilterGroup),
                    q => q.WhereIn("group_id", request.FilterGroup)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterRole),
                    q => q.WhereContains("role_id", request.FilterRole)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<GroupRoleDto>(query);
            return results.ToList();
        }
        public async Task<List<GroupRoleDto>> GetGroupRoleByCriteria(GetGroupRoleByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.GroupRoles)
                .Select("group_role_id AS GroupRoleId",
                      "group_id AS GroupId",
                      "role_id AS RoleId",
                      "is_active AS IsActive",
                      "parent_menu_id AS ParentMenuId",
                      "inserted_by AS InsertedBy",
                      "inserted_date AS InsertedDate",
                      "modified_by AS ModifiedBy",
                      "modified_date AS ModifiedDate")
                 .When(
                    !string.IsNullOrWhiteSpace(request.FilterGroup),
                    q => q.WhereIn("group_id", request.FilterGroup)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterRole),
                    q => q.WhereContains("role_id", request.FilterRole)
                );

            var results = await db.GetAsync<GroupRoleDto>(query);
            return results.ToList();
        }
        #endregion

        #region [User Group]
        public async Task<List<UserGroupDto>> GetUserGroupList(GetUserGroupCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.UserGroups)
                .Select("user_group_id AS UserGroupId",
                      "user_id AS UserId",
                      "group_id AS GroupId",
                      "is_active AS IsActive",
                      "inserted_by AS InsertedBy",
                      "inserted_date AS InsertedDate",
                      "modified_by AS ModifiedBy",
                      "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterUser),
                    q => q.WhereIn("user_id", request.FilterUser)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterGroup),
                    q => q.WhereContains("group_id", request.FilterGroup)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<UserGroupDto>(query);
            return results.ToList();
        }
        public async Task<List<UserGroupDto>> GetUserGroupByCriteria(GetUserGroupByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.UserGroups)
                .Select("user_group_id AS UserGroupId",
                      "user_id AS UserId",
                      "group_id AS GroupId",
                      "is_active AS IsActive",
                      "inserted_by AS InsertedBy",
                      "inserted_date AS InsertedDate",
                      "modified_by AS ModifiedBy",
                      "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterUser),
                    q => q.WhereIn("user_id", request.FilterUser)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterGroup),
                    q => q.WhereContains("group_id", request.FilterGroup)
                );

            var results = await db.GetAsync<UserGroupDto>(query);
            return results.ToList();
        }
        #endregion
    }
}
