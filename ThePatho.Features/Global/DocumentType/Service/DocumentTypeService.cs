using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.DocumentType.Commands;
using ThePatho.Features.Global.DocumentType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.DocumentType.Service
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public DocumentTypeService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<DocumentTypeItemDto>> GetDocumentType(GetDocumentTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@DocumentTypeCode", request.FilterDocumentTypeCode ?? (object)DBNull.Value);
                parameters.Add("@DocumentTypeName", request.FilterDocumentTypeName ?? (object)DBNull.Value);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/DocumentType/Sql/get_documenttype");
                var data = await dbConnection.QueryAsync<DocumentTypeDto>(query, parameters);
                var result = new DocumentTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    DocumentTypeList = data.ToList(),
                };
                return new ApiResponse<DocumentTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<DocumentTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<DocumentTypeDto>> GetSingleDocumentType(GetSingleDocumentTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DocumentTypeCode", request.DocumentTypeCode ?? (object)DBNull.Value);

                var query = await queryLoader.LoadQueryAsync("Global/DocumentType/Sql/get_single_documenttype");

                var data = await dbConnection.QueryFirstOrDefaultAsync<DocumentTypeDto>(query, parameters);

                if (data == null)
                {
                    return new ApiResponse<DocumentTypeDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<DocumentTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<DocumentTypeDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<DocumentTypeItemDto>> GetDocumentTypeByCriteria(GetDocumentTypeByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DocumentTypeCode", request.DocumentTypeCode ?? "");
                parameters.Add("@DocumentTypeName", request.DocumentTypeName ?? "");


                var query = await queryLoader.LoadQueryAsync("Global/DocumentType/Sql/get_criteria_documenttype");
                var data = await dbConnection.QueryAsync<DocumentTypeDto>(query, parameters);
                var result = new DocumentTypeItemDto
                {
                    DataOfRecords = data.Count(),
                    DocumentTypeList = data.ToList(),
                };
                return new ApiResponse<DocumentTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<DocumentTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitDocumentType(SubmitDocumentTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DocumentTypeCode", request.DocumentTypeCode);
                parameters.Add("@DocumentTypeName", request.DocumentTypeName);
                parameters.Add("@Action", request.Action);
                var userName = currentUserService.GetUserName();
                parameters.Add("@User", string.IsNullOrWhiteSpace(userName) ? "admin" : userName);

                var query = await queryLoader.LoadQueryAsync("Global/DocumentType/Sql/submit_documenttype");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.DocumentTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.DocumentTypeCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteDocumentType(DeleteDocumentTypeCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DocumentTypeCode", request.DocumentTypeCode);

                var query_single = await queryLoader.LoadQueryAsync("Global/DocumentType/Sql/get_single_documenttype");

                var data_single = await dbConnection.QueryFirstOrDefaultAsync<DocumentTypeDto>(query_single, parameters);

                if (data_single == null)
                {
                    return new ApiResponse<DocumentTypeDto>(HttpStatusCode.NotFound, "data not found");
                }

                var query = await queryLoader.LoadQueryAsync("Global/DocumentType/Sql/delete_documenttype");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message.ToString());
            }
        }

    }
}
