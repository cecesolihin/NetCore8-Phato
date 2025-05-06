using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Features.Applicant.ApplicantSkill.Commands;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;
using ThePatho.Features.Applicant.ApplicantSkill.Service;
using ThePatho.Provider.ApiResponse;
using ThePatho.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Applicant.ApplicantSkill.Service
{
    public class ApplicantSkillService : IApplicantSkillService
    {
        private readonly DapperContext dapperContext; 

        public ApplicantSkillService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<ApiResponse<ApplicantSkillItemDto>> GetApplicantSkill(GetApplicantSkillCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.ApplicantSkill)
                    .Select("applicant_no as ApplicantNo",
                            "skill_code as SkillCode",
                            "description as Description",
                            "proficiency_code as ProficiencyCode",
                            "taken_date as TakenDate",
                            "exp_date as Expdate",
                            "remarks as Remarks",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                        q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterSkill),
                            q => q.WhereContains("skill_code", request.FilterSkill)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<ApplicantSkillDto>(query);
                var result = new ApplicantSkillItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    ApplicantSkillList = data.ToList(),
                };
                return new ApiResponse<ApplicantSkillItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<ApplicantSkillItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<ApiResponse<ApplicantSkillDto>> GetApplicantSkillByCriteria(GetApplicantSkillByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.ApplicantSkill)
                    .Select("applicant_no as ApplicantNo",
                            "skill_code as SkillCode",
                            "description as Description",
                            "proficiency_code as ProficiencyCode",
                            "taken_date as TakenDate",
                            "exp_date as Expdate",
                            "remarks as Remarks",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                        q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                    );
                var data = await db.FirstOrDefaultAsync<ApplicantSkillDto>(query);
                return new ApiResponse<ApplicantSkillDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return new ApiResponse<ApplicantSkillDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }
        public async Task<ApiResponse> SubmitApplicantSkill(SubmitApplicantSkillCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                if (string.IsNullOrWhiteSpace(request.ApplicantNo) || string.IsNullOrWhiteSpace(request.SkillCode))
                {
                    throw new ArgumentException("ApplicantNo and SkillCode are required.");
                }

                // Check if data exists
                var existsQuery = new Query(TableName.ApplicantSkill)
                    .Where("applicant_no", request.ApplicantNo)
                    .Where("skill_code", request.SkillCode)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Kondisi Add (Insert)
                    var insertQuery = new Query(TableName.ApplicantSkill).AsInsert(new
                    {
                        applicant_no = request.ApplicantNo,
                        skill_code = request.SkillCode,
                        description = request.Description,
                        proficiency_code = request.ProficiencyCode,
                        taken_date = request.TakenDate,
                        exp_date = request.ExpDate,
                        remarks = request.Remarks,
                        inserted_by = "system",
                        inserted_date = DateTime.UtcNow,
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                  
                }
                else
                {
                    // Kondisi Edit (Update)
                    var updateQuery = new Query(TableName.ApplicantSkill)
                        .Where("applicant_no", request.ApplicantNo)
                        .Where("skill_code", request.SkillCode)
                        .AsUpdate(new
                        {
                            description = request.Description,
                            proficiency_code = request.ProficiencyCode,
                            taken_date = request.TakenDate,
                            exp_date = request.ExpDate,
                            remarks = request.Remarks,
                            modified_by = "system",
                            modified_date = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                 
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.ApplicantNo} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.ApplicantNo}", ex.Message.ToString());
            }

        }
        public async Task<ApiResponse> DeleteApplicantSkill(DeleteApplicantSkillCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.ApplicantNo) || string.IsNullOrWhiteSpace(request.SkillCode))
                    throw new ArgumentException("ApplicantNo and SkillCode are required.");

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableName.ApplicantSkill)
                    .Where("applicant_no", request.ApplicantNo)
                    .Where("skill_code", request.SkillCode)
                    .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.ApplicantNo} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.ApplicantNo}", ex.Message.ToString());
            }
        }

    }
}
