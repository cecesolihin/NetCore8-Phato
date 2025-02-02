using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.Recruitment.MPP.Commands;
using ThePatho.Features.Recruitment.MPP.DTO;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Infrastructure.Persistance;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Recruitment.MPP.Service
{
    public class MPPService : IMPPService
    {
        private readonly DapperContext dapperContext;
        public MPPService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<NewApiResponse<MPPItemDto>> GetMPP(GetMPPCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.MPP)
                    .Select(
                            "mpp_no AS MppNo",
                            "mpp_year AS MppYear",
                            "period_code AS PeriodCode",
                            "remarks AS Remarks",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate"
                        )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterMppNo),
                        q => q.WhereIn("mpp_no", request.FilterMppNo)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterPeriodCode),
                            q => q.WhereContains("period_code", request.FilterPeriodCode)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterPeriodCode),
                            q => q.WhereContains("mpp_year", request.FilterPeriodCode)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<MPPDto>(query);
                var result = new MPPItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    MPPList = data.ToList(),
                };
                return new NewApiResponse<MPPItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<MPPItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<NewApiResponse<MPPDto>> GetMPPByCriteria(GetMPPByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.MPP)
                    .Select(
                            "mpp_no AS MppNo",
                            "mpp_year AS MppYear",
                            "period_code AS PeriodCode",
                            "remarks AS Remarks",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate"
                        )
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterMPPNo),
                        q => q.WhereIn("mpp_no", request.FilterMPPNo)
                    );
                var data = await db.FirstOrDefaultAsync<MPPDto>(query);
                return new NewApiResponse<MPPDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<MPPDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }
        public async Task<ApiResponse> SubmitMPP(SubmitMPPCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                // Cek apakah data sudah ada berdasarkan ApplicantNo dan IdentityCode
                var existingRecord = await db.Query(TableName.MPP)
                    .Where("mpp_no", request.MppNo)
                    .FirstOrDefaultAsync();

                if (existingRecord == null)
                {
                    // Kondisi ADD (Insert)
                    var insertQuery = new Query(TableName.MPP).AsInsert(new
                    {
                        mpp_no = request.MppNo,
                        mpp_year = request.MppYear,
                        period_code = request.PeriodCode,
                        remarks = request.Remarks,
                        inserted_by = "system",
                        inserted_date = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                  
                }
                else
                {
                    var updateQuery = new Query(TableName.MPP)
                                .Where("mpp_no", request.MppNo)
                                .AsUpdate(new
                                {
                                    mpp_year = request.MppYear,
                                    period_code = request.PeriodCode,
                                    remarks = request.Remarks,
                                    modified_by = "system",
                                    modified_date = DateTime.UtcNow
                                });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                  
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.MppNo} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.MppNo}", ex.Message.ToString());
            }
        }
        public async Task<ApiResponse> DeleteMPP(DeleteMPPCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableName.MPP)
                    .Where("mpp_no", request.MPPNo)
                    .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.MPPNo} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.MPPNo}", ex.Message.ToString());
            }
        }
    }
}
