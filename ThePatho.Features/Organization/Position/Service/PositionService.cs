using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.Organization.Position.Commands;
using ThePatho.Features.Organization.Position.DTO;
using ThePatho.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Organization.Position.Service
{
    public class PositionService : IPositionService
    {
        private readonly DapperContext dapperContext; 

        public PositionService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<ApiResponse<PositionItemDto>> GetPosition(GetPositionCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.Position)
                    .Select(
                           "position_code AS PositionCode",
                            "position_name AS PositionName",
                            "job_level_code AS JobLevelCode",
                            "org_structure_id AS OrgStructureId",
                            "act_as_head AS ActAsHead",
                            "objective AS Objective",
                            "job_description AS JobDescription",
                            "is_deleted AS IsDeleted",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate"
                        )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterPositionCode),
                        q => q.WhereIn("position_code", request.FilterPositionCode)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterPositionName),
                            q => q.WhereContains("position_name", request.FilterPositionName)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<PositionDto>(query);

                var result = new PositionItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    PositionList = data.ToList(),
                };
                return new ApiResponse<PositionItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<PositionItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<PositionDto>> GetPositionByCriteria(GetPositionByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.Position)
                    .Select(
                            "position_code AS PositionCode",
                            "position_name AS PositionName",
                            "job_level_code AS JobLevelCode",
                            "org_structure_id AS OrgStructureId",
                            "act_as_head AS ActAsHead",
                            "objective AS Objective",
                            "job_description AS JobDescription",
                            "is_deleted AS IsDeleted",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate"
                        )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterOrgStructureId),
                        q => q.WhereIn("org_structure_id", request.FilterOrgStructureId)
                    );

                var data = await db.FirstOrDefaultAsync<PositionDto>(query);
                return new ApiResponse<PositionDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<PositionDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitPosition(SubmitPositionCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                if (string.IsNullOrWhiteSpace(request.PositionCode))
                {
                    throw new ArgumentException("Position Code is required.");
                }

                var existsQuery = new Query(TableName.Position)
                    .Where("position_code", request.PositionCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableName.Position).AsInsert(new
                    {
                        position_code = request.PositionCode,
                        position_name = request.PositionName,
                        job_level_code = request.JobLevelCode,
                        org_structure_id = request.OrgStructureId,
                        act_as_head = request.ActAsHead,
                        objective = request.Objective,
                        job_description = request.JobDescription,
                        is_deleted = false,
                        inserted_by = "system",
                        inserted_date = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableName.Position)
                        .Where("position_code", request.PositionCode)
                        .AsUpdate(new
                        {
                            position_name = request.PositionName,
                            job_level_code = request.JobLevelCode,
                            org_structure_id = request.OrgStructureId,
                            act_as_head = request.ActAsHead,
                            objective = request.Objective,
                            job_description = request.JobDescription,
                            modified_by = "system",
                            modified_date = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.PositionCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.PositionCode}", ex.Message.ToString());
            }
        }
        public async Task<ApiResponse> DeletePosition(DeletePositionCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.PositionCode))
                    throw new ArgumentException("Position is required.");

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableName.Position)
                                .Where("position_code", request.PositionCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.PositionCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.PositionCode}", ex.Message.ToString());
            }
            
        }

    }
}
