using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeDocument.Commands;
using ThePatho.Features.PersonalInformation.EmployeeDocument.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeDocument.Service
{
    public class EmployeeDocumentService : IEmployeeDocumentService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        #endregion

        #region [CTOR]
        public EmployeeDocumentService(DapperContext _dapperContext, SqlQueryLoader _queryLoader)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmployeeDocumentItemDto>> GetEmployeeDocument(GetEmployeeDocumentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@DocumentTypeCode", request.FilterDocumentTypeCode ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeDocument/Sql/get_emp_document");
                var data = await db.QueryAsync<EmployeeDocumentDto>(query, parameters);

                var result = new EmployeeDocumentItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeDocumentList = data.ToList()
                };

                return new ApiResponse<EmployeeDocumentItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeDocumentItemDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Document list.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeDocumentDto>> GetSingleEmployeeDocument(GetSingleEmployeeDocumentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeDocumentId", request.EmployeeDocumentId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeDocument/Sql/get_single_emp_document");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeDocumentDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeDocumentDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<EmployeeDocumentDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeDocumentDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Document detail.", ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeDocumentItemDto>> GetEmployeeDocumentByCriteria(GetEmployeeDocumentByCriteriaCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.FilterEmployeeId ?? 0);
                parameters.Add("@DocumentTypeCode", request.FilterDocumentTypeCode ?? string.Empty);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeDocument/Sql/get_criteria_emp_document");
                var data = await db.QueryAsync<EmployeeDocumentDto>(query, parameters);

                var result = new EmployeeDocumentItemDto
                {
                    DataOfRecords = data.Count(),
                    EmployeeDocumentList = data.ToList()
                };

                return new ApiResponse<EmployeeDocumentItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeDocumentItemDto>(HttpStatusCode.BadRequest, "Error filtering Employee Document data.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeDocument(SubmitEmployeeDocumentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeDocumentId", request.EmployeeDocumentId);
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@DocumentTypeCode", request.DocumentTypeCode);
                parameters.Add("@FilePath", request.FilePath);
                parameters.Add("@Remark", request.Remark);
                parameters.Add("@InsertedBy", request.InsertedBy);
                parameters.Add("@InsertedDate", request.InsertedDate);
                parameters.Add("@ModifiedBy", request.ModifiedBy);
                parameters.Add("@ModifiedDate", request.ModifiedDate);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeDocument/Sql/submit_emp_document");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployeeDocument(DeleteEmployeeDocumentCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeDocumentId", request.EmployeeDocumentId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeDocument/Sql/get_single_emp_document");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeDocumentDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<EmployeeDocumentDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query_delete = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeDocument/Sql/delete_emp_document");
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

