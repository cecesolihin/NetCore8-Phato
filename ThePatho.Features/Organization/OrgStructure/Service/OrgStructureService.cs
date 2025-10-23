using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgStructure.Commands;
using ThePatho.Features.Organization.OrgStructure.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Domain.Models.Organization;

namespace ThePatho.Features.Organization.OrgStructure.Service
{
    public class OrgStructureService : IOrgStructureService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public OrgStructureService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<OrgStructureItemDto>> GetOrgStructure(GetOrgStructureCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.OrgStructure)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgStructureCode),
                        q => q.WhereContains("OrgStructureCode", request.OrgStructureCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgStructureName),
                        q => q.WhereContains("OrgStructureName", request.OrgStructureName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgLevelCode),
                        q => q.WhereContains("OrgLevelCode", request.OrgLevelCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.Status),
                        q => q.Where("Status", request.Status)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<OrgStructureDto>(query);

                var result = new OrgStructureItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    OrgStructureList = data.ToList(),
                };
                return new ApiResponse<OrgStructureItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<OrgStructureItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<OrgStructureItemDto>> GetOrgStructureByCriteria(GetOrgStructureByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.OrgStructure)
                .Select("*")
                    .When(
                        request.OrgStructureId > 0,
                        q => q.WhereContains("OrgStructureId", request.OrgStructureId)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgStructureCode),
                        q => q.WhereContains("OrgStructureCode", request.OrgStructureCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgStructureName),
                        q => q.WhereContains("OrgStructureName", request.OrgStructureName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgLevelCode),
                        q => q.WhereContains("OrgLevelCode", request.OrgLevelCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.Status),
                        q => q.Where("Status", request.Status)
                    );

                var data = await db.GetAsync<OrgStructureDto>(query);

                var result = new OrgStructureItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    OrgStructureList = data.ToList(),
                };
                return new ApiResponse<OrgStructureItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<OrgStructureItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitOrgStructure(SubmitOrgStructureCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var validationErrors = new List<string>();

                if (string.IsNullOrWhiteSpace(request.OrgStructureCode))
                    validationErrors.Add("OrgStructure Code is required.");

                if (string.IsNullOrWhiteSpace(request.OrgStructureName))
                    validationErrors.Add("OrgStructure Name is required.");

                if (string.IsNullOrWhiteSpace(request.OrgLevelCode))
                    validationErrors.Add("OrgLevel Code is required.");


                if (string.IsNullOrWhiteSpace(request.Action) ||
                    (request.Action.ToUpper() != "INSERT" && request.Action.ToUpper() != "UPDATE"))
                    validationErrors.Add("Action must be either 'INSERT' or 'UPDATE'.");

                if (validationErrors.Any())
                {
                    return new ApiResponse(
                        HttpStatusCode.BadRequest,
                        $"Validation failed for {request.OrgStructureCode}",
                        string.Join("; ", validationErrors)
                    );
                }

                if (request.Action.ToUpper() == "INSERT")
                {
                    var existsQuery = new Query(TableOrganization.OrgStructure)
                        .Where("OrgStructureCode", request.OrgStructureCode)
                        .SelectRaw("COUNT(1)");

                    var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                    if (exists > 0)
                    {
                        return new ApiResponse(
                            HttpStatusCode.BadRequest,
                            $"OrgStructure with code {request.OrgStructureCode} already exists."
                        );
                    }

                    // Insert new record
                    var insertQuery = new Query(TableOrganization.OrgStructure).AsInsert(new
                    {
                        OrgStructureCode = request.OrgStructureCode,
                        OrgStructureName = request.OrgStructureName,
                        ParentOrgId = request.ParentOrgId ?? (object)DBNull.Value,
                        OrgLevelCode = request.OrgLevelCode,
                        Status = request.Status.ToString(), 
                        IsDeleted = false,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);

                    if (insertResult == 0)
                    {
                        return new ApiResponse(
                            HttpStatusCode.BadRequest,
                            $"Failed to insert org structure {request.OrgStructureCode}"
                        );
                    }
                }
                else if (request.Action.ToUpper() == "UPDATE")
                {
                    if (request.OrgStructureId == 0)
                    {
                        return new ApiResponse(
                            HttpStatusCode.BadRequest,
                            "OrgStructure ID is required for update operation."
                        );
                    }

                    // Cek apakah record exists untuk update
                    var existsQuery = new Query(TableOrganization.OrgStructure)
                        .Where("OrgStructureId", request.OrgStructureId)
                        .SelectRaw("COUNT(1)");

                    var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                    if (exists == 0)
                    {
                        return new ApiResponse(
                            HttpStatusCode.NotFound,
                            $"OrgStructure with ID {request.OrgStructureId} not found."
                        );
                    }

                    // Update existing record
                    var updateQuery = new Query(TableOrganization.OrgStructure)
                        .Where("OrgStructureId", request.OrgStructureId)
                        .AsUpdate(new
                        {
                            OrgStructureCode = request.OrgStructureCode,
                            OrgStructureName = request.OrgStructureName,
                            ParentOrgId = request.ParentOrgId ?? (object)DBNull.Value,
                            OrgLevelCode = request.OrgLevelCode,
                            Status = request.Status.ToString(),
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);

                    if (updateResult == 0)
                    {
                        return new ApiResponse(
                            HttpStatusCode.BadRequest,
                            $"Failed to update org structure {request.OrgStructureCode}"
                        );
                    }
                }

                var actionMessage = request.Action.ToUpper() == "ADD" ? "created" : "updated";
                return new ApiResponse(
                    HttpStatusCode.OK,
                    $"Org structure {request.OrgStructureCode} {actionMessage} successfully"
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse(
                    HttpStatusCode.BadRequest,
                    $"Failed to {request.Action} org structure {request.OrgStructureCode}",
                    ex.Message
                );
            }
        }
        public async Task<ApiResponse> DeleteOrgStructure(DeleteOrgStructureCommand request)
        {
            try
            {
                if (request.OrgStructureId > 0)
                {
                    return new ApiResponse<OrgStructureDto>(
                         HttpStatusCode.BadRequest,
                         "OrgStructure is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.OrgStructure)
                                .Where("OrgStructureId", request.OrgStructureId)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete ", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<OrgStructureDto>> GetSingleOrgStructure(GetSingleOrgStructureCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.OrgStructure)
                    .Select("*")
                    .Where("OrgStructureId", request.OrgStructureId);

                var data = await db.FirstOrDefaultAsync<OrgStructureDto>(query);

                if (data == null)
                {
                    return new ApiResponse<OrgStructureDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<OrgStructureDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<OrgStructureDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
