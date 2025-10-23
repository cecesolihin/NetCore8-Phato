using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Position.Commands;
using ThePatho.Features.Organization.Position.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Features.Organization.Grade.DTO;

namespace ThePatho.Features.Organization.Position.Service
{
    public class PositionService : IPositionService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext; 

        public PositionService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<PositionItemDto>> GetPosition(GetPositionCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Position)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterPositionCode),
                        q => q.WhereIn("PositionCode", request.FilterPositionCode)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterPositionName),
                            q => q.WhereContains("PositionName", request.FilterPositionName)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
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

        public async Task<ApiResponse<PositionItemDto>> GetPositionByCriteria(GetPositionByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Position)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterOrgStructureId),
                        q => q.WhereIn("OrgStructureID", request.FilterOrgStructureId)
                    );

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

                var existsQuery = new Query(TableOrganization.Position)
                    .Where("PositionCode", request.PositionCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.Position).AsInsert(new
                    {
                        PositionCode = request.PositionCode,
                        PositionName = request.PositionName,
                        JobLevelCode = request.JobLevelCode,
                        OrgStructureId = request.OrgStructureId,
                        ActAsHead = request.ActAsHead,
                        Objective = request.Objective,
                        JobDescription = request.JobDescription,
                        IsDeleted = false,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update
                    var updateQuery = new Query(TableOrganization.Position)
                        .Where("position_code", request.PositionCode)
                        .AsUpdate(new
                        {
                            PositionName = request.PositionName,
                            JobLevelCode = request.JobLevelCode,
                            OrgStructureId = request.OrgStructureId,
                            ActAsHead = request.ActAsHead,
                            Objective = request.Objective,
                            JobDescription = request.JobDescription,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
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
                {
                    return new ApiResponse<PositionDto>(
                         HttpStatusCode.BadRequest,
                         "Position is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.Position)
                                .Where("PositionCode", request.PositionCode)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.PositionCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.PositionCode}", ex.Message.ToString());
            }
            
        }

        public async Task<ApiResponse<PositionDto>> GetSinglePosition(GetSinglePositionCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.Position)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterPositionCode),
                        q => q.WhereIn("PositionCode", request.FilterPositionCode)
                    );

                var data = await db.FirstOrDefaultAsync<PositionDto>(query);

                if (data == null)
                {
                    return new ApiResponse<PositionDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
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
        #endregion
    }
}
