using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.Commands.Group;
using ThePatho.Features.Identity.UserManagement.Commands.GroupRole;
using ThePatho.Features.Identity.UserManagement.Commands.Role;
using ThePatho.Features.Identity.UserManagement.Commands.User;
using ThePatho.Features.Identity.UserManagement.Commands.UserGroup;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<ApiResponse<UserItemDto>> GetUserList(GetUserCommand request)
        {
            try
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
                        q => q.WhereContains("username", request.FilterUserName)
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

                var data = await db.GetAsync<UserDto>(query);
                var result = new UserItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    UserList = data.ToList(),
                };
                return new ApiResponse<UserItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<UserItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }
        public async Task<ApiResponse<UserDto>> GetUserByCriteria(GetUserByCriteriaCommand request)
        {
            try
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
                
                return new ApiResponse<UserDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return new ApiResponse<UserDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }
        #endregion

        #region [Group]
        public async Task<ApiResponse<GroupItemDto>> GetGroupList(GetGroupCommand request)
        {
            try 
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

                var data = await db.GetAsync<GroupDto>(query);
                var result = new GroupItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    GroupList = data.ToList(),
                };
                return new ApiResponse<GroupItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<GroupItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }
        public async Task<ApiResponse<GroupDto>> GetGroupByCriteria(GetGroupByCriteriaCommand request)
        {
            try 
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
               
                return new ApiResponse<GroupDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return new ApiResponse<GroupDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }
        #endregion

        #region [Role]
        public async Task<ApiResponse<RoleItemDto>> GetRoleList(GetRoleCommand request)
        {
            try
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

                var data = await db.GetAsync<RoleDto>(query);
                var result = new RoleItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    RoleList = data.ToList(),
                };
                return new ApiResponse<RoleItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<RoleItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }
        public async Task<ApiResponse<RoleItemDto>> GetRoleByCriteria(GetRoleByCriteriaCommand request)
        {
            try
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

                var data = await db.GetAsync<RoleDto>(query);
                var result = new RoleItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    RoleList = data.ToList(),
                };
                return new ApiResponse<RoleItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<RoleItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }
        #endregion

        #region [Group Role]
        public async Task<ApiResponse<GroupRoleItemDto>> GetGroupRoleList(GetGroupRoleCommand request)
        {
            try 
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

                var data = await db.GetAsync<GroupRoleDto>(query);
                var result = new GroupRoleItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    GroupRoleList = data.ToList(),
                };
                return new ApiResponse<GroupRoleItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<GroupRoleItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }
        public async Task<ApiResponse<GroupRoleItemDto>> GetGroupRoleByCriteria(GetGroupRoleByCriteriaCommand request)
        {
            try
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

                var data = await db.GetAsync<GroupRoleDto>(query);
                var result = new GroupRoleItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    GroupRoleList = data.ToList(),
                };
                return new ApiResponse<GroupRoleItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<GroupRoleItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }
        #endregion

        #region [User Group]
        public async Task<ApiResponse<UserGroupItemDto>> GetUserGroupList(GetUserGroupCommand request)
        {
            try 
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

                var data = await db.GetAsync<UserGroupDto>(query);
                var result = new UserGroupItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    UserGroupList = data.ToList(),
                };
                return new ApiResponse<UserGroupItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<UserGroupItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }
        public async Task<ApiResponse<UserGroupItemDto>> GetUserGroupByCriteria(GetUserGroupByCriteriaCommand request)
        {
            try 
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

                var data = await db.GetAsync<UserGroupDto>(query);
                    var result = new UserGroupItemDto
                    {
                        DataOfRecords = data.ToList().Count,
                    UserGroupList = data.ToList(),
                };
                return new ApiResponse<UserGroupItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<UserGroupItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }
        #endregion
    }
}
