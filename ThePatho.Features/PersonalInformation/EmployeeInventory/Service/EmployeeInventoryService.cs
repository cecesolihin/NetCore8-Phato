using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeInventory.Commands;
using ThePatho.Features.PersonalInformation.EmployeeInventory.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Service
{
    public class EmployeeInventoryService : IEmployeeInventoryService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        #endregion

        #region [CTOR]
        public EmployeeInventoryService(DapperContext _dapperContext, SqlQueryLoader _queryLoader)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeInventoryItemDto>> GetEmployeeInventory(GetEmployeeInventoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@InventoryNo", request.FilterInventoryNo ?? string.Empty);
                parameters.Add("@InventoryName", request.FilterInventoryName ?? string.Empty);
                parameters.Add("@InventoryTypeCode", request.FilterInventoryTypeCode ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeInventory/Sql/get_emp_inventory");
                var data = await db.QueryAsync<EmployeeInventoryDto>(query, parameters);

                var result = new EmployeeInventoryItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeInventoryList = data.ToList()
                };

                return new ApiResponse<EmployeeInventoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeInventoryItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Inventory list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeInventoryDto>> GetSingleEmployeeInventory(GetSingleEmployeeInventoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@InventoryNo", request.InventoryNo);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeInventory/Sql/get_single_emp_inventory");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeInventoryDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeInventoryDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeInventoryDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeInventoryDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Inventory detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeInventoryItemDto>> GetEmployeeInventoryByCriteria(GetEmployeeInventoryByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@InventoryNo", request.FilterInventoryNo ?? string.Empty);
                parameters.Add("@InventoryName", request.FilterInventoryName ?? string.Empty);
                parameters.Add("@InventoryTypeCode", request.FilterInventoryTypeCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeInventory/Sql/get_criteria_emp_inventory");
                var data = await db.QueryAsync<EmployeeInventoryDto>(query, parameters);

                var result = new EmployeeInventoryItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeInventoryList = data.ToList()
                };

                return new ApiResponse<EmployeeInventoryItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeInventoryItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Inventory data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeInventory(SubmitEmployeeInventoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@InventoryNo", request.InventoryNo);
                parameters.Add("@InventoryTypeCode", request.InventoryTypeCode);
                parameters.Add("@InventoryName", request.InventoryName);
                parameters.Add("@ReceivedDate", request.ReceivedDate);
                parameters.Add("@ReturnPlanDate", request.ReturnPlanDate);
                parameters.Add("@Qty", request.Qty);
                parameters.Add("@Size", request.Size);
                parameters.Add("@InCondition", request.InCondition);
                parameters.Add("@InRemark", request.InRemark);
                parameters.Add("@ReturnDate", request.ReturnDate);
                parameters.Add("@OutCondition", request.OutCondition);
                parameters.Add("@OutRemark", request.OutRemark);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeInventory/Sql/submit_emp_inventory");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeInventory(DeleteEmployeeInventoryCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@InventoryNo", request.InventoryNo);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeInventory/Sql/get_single_emp_inventory");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeInventoryDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeInventoryDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeInventory/Sql/delete_emp_inventory");
                await db.ExecuteAsync(query_delete, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"Delete successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message);
            }
        }
        #endregion
    }
}

