using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;
using ThePatho.Features.Applicant.ApplicantEducation.Commands;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;
using ThePatho.Features.Applicant.ApplicantEducation.Service;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Applicant.ApplicantEducation.Service
{
    public class ApplicantEducationService : IApplicantEducationService
    {
        private readonly DapperContext dapperContext; 

        public ApplicantEducationService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }


        public async Task<NewApiResponse<ApplicantEducationItemDto>> GetApplicantEducation(GetApplicantEducationCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.ApplicantEducation)
                    .Select("applicant_no AS ApplicantNo",
                            "edu_level_code AS EduLevelCode",
                            "major_code AS MajorCode",
                            "faculty AS Faculty",
                            "start_year AS StartYear",
                            "end_year AS EndYear",
                            "gpa AS GPA",
                            "max_gpa AS MaxGPA",
                            "institution AS Institution",
                            "address AS Address",
                            "city_code AS CityCode",
                            "grad_type_code AS GradTypeCode",
                            "certificate_no AS CertificateNo",
                            "certificate_date AS CertificateDate",
                            "remark AS Remark",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                        q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterEdulLevel),
                            q => q.WhereContains("edu_level_code", request.FilterEdulLevel)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterMajor),
                        q => q.WhereIn("major_code", request.FilterMajor)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterFaculty),
                            q => q.WhereContains("faculty", request.FilterFaculty)
                     ).When(
                        !string.IsNullOrWhiteSpace(request.FilterInstitution),
                            q => q.WhereContains("institution", request.FilterInstitution)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<ApplicantEducationDto>(query);
                var result = new ApplicantEducationItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    ApplicantEducationList = data.ToList(),
                };
                return new NewApiResponse<ApplicantEducationItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<ApplicantEducationItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<NewApiResponse<ApplicantEducationDto>> GetApplicantEducationByCriteria(GetApplicantEducationByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.ApplicantEducation)
                    .Select("applicant_no AS ApplicantNo",
                            "edu_level_code AS EduLevelCode",
                            "major_code AS MajorCode",
                            "faculty AS Faculty",
                            "start_year AS StartYear",
                            "end_year AS EndYear",
                            "gpa AS GPA",
                            "max_gpa AS MaxGPA",
                            "institution AS Institution",
                            "address AS Address",
                            "city_code AS CityCode",
                            "grad_type_code AS GradTypeCode",
                            "certificate_no AS CertificateNo",
                            "certificate_date AS CertificateDate",
                            "remark AS Remark",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                        q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                    );
                var data = await db.FirstOrDefaultAsync<ApplicantEducationDto>(query);
                
                return new NewApiResponse<ApplicantEducationDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<ApplicantEducationDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<ApiResponse> SubmitApplicantEducation(SubmitApplicantEducationCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                // Cek apakah data sudah ada berdasarkan ApplicantNo dan EduLevelCode
                var existingRecord = await db.Query(TableName.ApplicantEducation)
                    .Where("applicant_no", request.ApplicantNo)
                    .Where("edu_level_code", request.EduLevelCode)
                    .Where("major_code", request.MajorCode)
                    .FirstOrDefaultAsync();

                if (existingRecord == null)
                {
                    // Kondisi ADD (Insert)
                    var insertQuery = new Query(TableName.ApplicantEducation)
                        .AsInsert(new
                        {
                            applicant_no = request.ApplicantNo,
                            edu_level_code = request.EduLevelCode,
                            major_code = request.MajorCode,
                            faculty = request.Faculty,
                            start_year = request.StartYear,
                            end_year = request.EndYear,
                            gpa = request.GPA,
                            max_gpa = request.MaxGPA,
                            institution = request.Institution,
                            address = request.Address,
                            city_code = request.CityCode,
                            grad_type_code = request.GradTypeCode,
                            certificate_no = request.CertificateNo,
                            certificate_date = request.CertificateDate,
                            remark = request.Remark,
                            inserted_by = "system",
                            inserted_date = DateTime.UtcNow,
                        });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Kondisi EDIT (Update)
                    var updateQuery = new Query(TableName.ApplicantEducation)
                        .Where("applicant_no", request.ApplicantNo)
                        .Where("edu_level_code", request.EduLevelCode)
                        .Where("major_code", request.MajorCode)
                        .AsUpdate(new
                        {
                            faculty = request.Faculty,
                            start_year = request.StartYear,
                            end_year = request.EndYear,
                            gpa = request.GPA,
                            max_gpa = request.MaxGPA,
                            institution = request.Institution,
                            address = request.Address,
                            city_code = request.CityCode,
                            grad_type_code = request.GradTypeCode,
                            certificate_no = request.CertificateNo,
                            certificate_date = request.CertificateDate,
                            remark = request.Remark,
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
        public async Task<ApiResponse> DeleteApplicantEducation(DeleteApplicantEducationCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableName.ApplicantEducation)
                    .Where("applicant_no", request.ApplicantNo)
                    .Where("edu_level_code", request.EduLevelCode)
                    .Where("major_code", request.MajorCode)
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
