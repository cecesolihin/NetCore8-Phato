using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgStructure.Commands;
using ThePatho.Features.Organization.OrgStructure.DTO;
using ThePatho.Features.Organization.Position.DTO;
using ThePatho.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Organization.OrgStructure.Service
{
    public class OrgStructureService : IOrgStructureService
    {
        private readonly DapperContext dapperContext; 

        public OrgStructureService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<ApiResponse<OrgStructureItemDto>> GetOrgStructure(GetOrgStructureCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.OrgStructure)
                    .Select(
                           "org_structure_id AS OrgStructureId",
                            "org_structure_code AS OrgStructureCode",
                            "org_structure_name AS OrgStructureName",
                            "parent_org_id AS ParentOrgId",
                            "org_level_code AS OrgLevelCode",
                            "status AS Status",
                            "is_deleted AS IsDeleted",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate"
                        )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterOrgStructureCode),
                        q => q.WhereIn("org_structure_code", request.FilterOrgStructureCode)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterOrgStructureName),
                            q => q.WhereContains("org_structure_name", request.FilterOrgStructureName)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterOrgStructureName),
                            q => q.WhereContains("org_level_code", request.FilterOrgLevelCode)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
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

        public async Task<ApiResponse<OrgStructureDto>> GetOrgStructureByCriteria(GetOrgStructureByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.OrgStructure)
                    .Select(
                            "org_structure_id AS OrgStructureId",
                            "org_structure_code AS OrgStructureCode",
                            "org_structure_name AS OrgStructureName",
                            "parent_org_id AS ParentOrgId",
                            "org_level_code AS OrgLevelCode",
                            "status AS Status",
                            "is_deleted AS IsDeleted",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate"
                        )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgLevelCode),
                        q => q.WhereIn("org_level_code", request.OrgLevelCode)
                    );

                var data = await db.FirstOrDefaultAsync<OrgStructureDto>(query);
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
        public async Task<ApiResponse> SubmitOrgStructure(SubmitOrgStructureCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                if (string.IsNullOrWhiteSpace(request.OrgStructureCode))
                {
                    throw new ArgumentException("Org Structure code is required.");
                }

                var existsQuery = new Query(TableName.OrgStructure)
                                .Where("org_structure_code", request.OrgStructureCode)
                                .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    var insertQuery = new Query(TableName.OrgStructure).AsInsert(new
                    {
                        org_structure_code = request.OrgStructureCode,
                        org_structure_name = request.OrgStructureName,
                        parent_org_id = request.ParentOrgId,
                        org_level_code = request.OrgLevelCode,
                        status = request.Status,
                        is_deleted = false,
                        inserted_by = "system",
                        inserted_date = DateTime.UtcNow
                    });

                }
                else
                {
                    var updateQuery = new Query(TableName.OrgStructure)
                        .Where("org_structure_code", request.OrgStructureCode)
                        .AsUpdate(new
                        {
                            org_structure_name = request.OrgStructureName,
                            parent_org_id = request.ParentOrgId,
                            org_level_code = request.OrgLevelCode,
                            status = request.Status,
                            modified_by = "system",
                            modified_date = DateTime.UtcNow
                        });

                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.OrgStructureCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.OrgStructureCode}", ex.Message.ToString());
            }
            
        }
        public async Task<ApiResponse> DeleteOrgStructure(DeleteOrgStructureCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.OrgStructureCode))
                    throw new ArgumentException("Org Structure Code is required.");

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableName.OrgStructure)
                            .Where("org_structure_code", request.OrgStructureCode)
                            .AsDelete();
                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.OrgStructureCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.OrgStructureCode}", ex.Message.ToString());
            }
        }

    }
}
