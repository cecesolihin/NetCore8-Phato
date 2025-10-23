using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.Grade.Commands;
using ThePatho.Features.Organization.Grade.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Grade.Service
{
    public class GradeService : IGradeService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public GradeService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<GradeItemDto>> GetGrade(GetGradeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Grade)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterGradeCode),
                        q => q.WhereContains("GradeCode", request.FilterGradeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterGradeName),
                        q => q.WhereContains("GradeName", request.FilterGradeName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterStatus),
                        q => q.Where("Status", request.FilterStatus)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<GradeDto>(query);

                var result = new GradeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    GradeList = data.ToList(),
                };
                return new ApiResponse<GradeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<GradeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<GradeItemDto>> GetGradeByCriteria(GetGradeByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Grade)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterGradeCode),
                        q => q.WhereContains("GradeCode", request.FilterGradeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterGradeName),
                        q => q.WhereContains("GradeName", request.FilterGradeName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterStatus),
                        q => q.Where("Status", request.FilterStatus)
                    );

                var data = await db.GetAsync<GradeDto>(query);

                var result = new GradeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    GradeList = data.ToList(),
                };
                return new ApiResponse<GradeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<GradeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitGrade(SubmitGradeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();
                // Validasi field NOT NULL berdasarkan struktur tabel
                if (string.IsNullOrWhiteSpace(request.GradeCode))
                    ArgumentException.Add("Grade Code is required.");

                if (string.IsNullOrWhiteSpace(request.GradeName))
                    ArgumentException.Add("Grade Name is required.");

                // Validasi panjang field sesuai constraint di database
                if (request.GradeCode.Length > 128)
                    ArgumentException.Add("Grade Code cannot exceed 128 characters.");

                if (request.GradeName.Length > 255)
                    ArgumentException.Add("Grade Name cannot exceed 255 characters.");

                if (request.Remarks != null && request.Remarks.Length > 500)
                    ArgumentException.Add("Remarks cannot exceed 500 characters.");

                // Validasi Order (tinyint range: 0-255)
                if (request.Order < 0 || request.Order > 255)
                    ArgumentException.Add("Order must be between 0 and 255.");

                if (ArgumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.GradeCode}", string.Join(", ", ArgumentException.ToArray()));
                }
                // Cek apakah GradeCode sudah exists
                var existsQuery = new Query(TableOrganization.Grade)
                    .Where("GradeCode", request.GradeCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.Grade).AsInsert(new
                    {
                        GradeCode = request.GradeCode,
                        GradeName = request.GradeName,
                        Status = request.Status,
                        Order = request.Order,
                        Remarks = request.Remarks,
                        IsDeleted = false,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.Grade)
                        .Where("GradeCode", request.GradeCode)
                        .AsUpdate(new
                        {
                            GradeName = request.GradeName,
                            Status = request.Status,
                            Order = request.Order,
                            Remarks = request.Remarks,
                            IsDeleted = false,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.GradeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.GradeCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteGrade(DeleteGradeCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.GradeCode))
                {
                    return new ApiResponse<GradeDto>(
                         HttpStatusCode.BadRequest,
                         "Grade is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.Grade)
                                .Where("GradeCode", request.GradeCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.GradeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.GradeCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<GradeDto>> GetSingleGrade(GetSingleGradeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Grade)
                    .Select("*")
                    .Where("GradeCode", request.GradeCode);

                var data = await db.FirstOrDefaultAsync<GradeDto>(query);

                if (data == null)
                {
                    return new ApiResponse<GradeDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<GradeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<GradeDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
