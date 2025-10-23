using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.EmploymentType.Commands;
using ThePatho.Features.Organization.EmploymentType.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.EmploymentType.Service
{
    public class EmploymentTypeService : IEmploymentTypeService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public EmploymentTypeService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<EmploymentTypeItemDto>> GetEmploymentType(GetEmploymentTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.EmploymentType)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterEmploymentTypeCode),
                        q => q.WhereContains("EmploymentTypeCode", request.FilterEmploymentTypeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterEmployementTypeName),
                        q => q.WhereContains("EmploymentTypeName", request.FilterEmployementTypeName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterStatus),
                        q => q.Where("Status", request.FilterStatus)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<EmploymentTypeDto>(query);

                var result = new EmploymentTypeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    EmploymentTypeList = data.ToList(),
                };
                return new ApiResponse<EmploymentTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmploymentTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<EmploymentTypeItemDto>> GetEmploymentTypeByCriteria(GetEmploymentTypeByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.EmploymentType)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterEmploymentTypeCode),
                        q => q.WhereContains("EmploymentTypeCode", request.FilterEmploymentTypeCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterEmployementTypeName),
                        q => q.WhereContains("EmploymentTypeName", request.FilterEmployementTypeName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterStatus),
                        q => q.Where("Status", request.FilterStatus)
                    );

                var data = await db.GetAsync<EmploymentTypeDto>(query);

                var result = new EmploymentTypeItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    EmploymentTypeList = data.ToList(),
                };
                return new ApiResponse<EmploymentTypeItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmploymentTypeItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitEmploymentType(SubmitEmploymentTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                // Validasi field NOT NULL berdasarkan struktur tabel
                var argumentException = new List<string>();
                if (string.IsNullOrWhiteSpace(request.EmploymentTypeCode))
                    argumentException.Add("EmploymentType Code is required.");

                if (string.IsNullOrWhiteSpace(request.EmployementTypeName))
                    argumentException.Add("EmploymentType Name is required.");

                if (string.IsNullOrWhiteSpace(request.Status))
                    argumentException.Add("Status is required.");

                // Validasi panjang field sesuai constraint di database
                if (request.EmploymentTypeCode.Length > 128)
                    argumentException.Add("EmploymentType Code cannot exceed 128 characters.");

                if (request.EmployementTypeName.Length > 255)
                    argumentException.Add("EmploymentType Name cannot exceed 255 characters.");

                if (request.Remarks != null && request.Remarks.Length > 500)
                    argumentException.Add("Remarks cannot exceed 500 characters.");

                // Validasi Order (tinyint range: 0-255)
                if (request.Order < 0 || request.Order > 255)
                    argumentException.Add("Order must be between 0 and 255.");

                // Validasi EmploymentPeriodMonth (jika ada)
                if (request.EmploymentPeriodMonth.HasValue && request.EmploymentPeriodMonth < 0)
                    argumentException.Add("Employment Period Month cannot be negative.");

                if (argumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.EmploymentTypeCode}", string.Join(", ", argumentException.ToArray()));
                }
                // Cek apakah EmploymentTypeCode sudah exists
                var existsQuery = new Query(TableOrganization.EmploymentType)
                    .Where("EmploymentTypeCode", request.EmploymentTypeCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.EmploymentType).AsInsert(new
                    {
                        EmploymentTypeCode = request.EmploymentTypeCode,
                        EmployementTypeName = request.EmployementTypeName,
                        Status = request.Status,
                        Order = request.Order,
                        Remarks = request.Remarks,
                        UseEndDate = request.UseEndDate,
                        EmploymentPeriodMonth = request.EmploymentPeriodMonth,
                        IsDeleted = request.IsDeleted,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.EmploymentType)
                        .Where("EmploymentTypeCode", request.EmploymentTypeCode) // Perbaiki typo: EmploymentType_code -> EmploymentTypeCode
                        .AsUpdate(new
                        {
                            EmployementTypeName = request.EmployementTypeName,
                            Status = request.Status,
                            Order = request.Order,
                            Remarks = request.Remarks,
                            UseEndDate = request.UseEndDate,
                            EmploymentPeriodMonth = request.EmploymentPeriodMonth,
                            IsDeleted = request.IsDeleted,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.EmploymentTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.EmploymentTypeCode}", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteEmploymentType(DeleteEmploymentTypeCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.EmploymentTypeCode))
                    return new ApiResponse(HttpStatusCode.NotFound, $"Delete {request.EmploymentTypeCode} EmploymentType is required.");
               
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.EmploymentType)
                                .Where("EmploymentTypeCode", request.EmploymentTypeCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.EmploymentTypeCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.EmploymentTypeCode}", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<EmploymentTypeDto>> GetSingleEmploymentType(GetSingleEmploymentTypeCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.EmploymentType)
                    .Select("*")
                    .Where("EmploymentTypeCode", request.EmploymentTypeCode);
                   
                var data = await db.FirstOrDefaultAsync<EmploymentTypeDto>(query);
                return new ApiResponse<EmploymentTypeDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmploymentTypeDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
