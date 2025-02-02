using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Features.Applicant.ApplicantDocument.Commands;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;
using ThePatho.Features.Applicant.ApplicantDocument.Service;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Applicant.ApplicantDocument.Service
{
    public class ApplicantDocumentService : IApplicantDocumentService
    {
        private readonly DapperContext dapperContext;  

        public ApplicantDocumentService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<NewApiResponse<ApplicantDocumentItemDto>> GetApplicantDocument(GetApplicantDocumentCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.ApplicantDocument)
                    .Select("applicant_no AS ApplicantNo",
                            "document_type_code AS DocumentTypeCode",
                            "file_path AS FilePath",
                            "remark AS Remark",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                        q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                     ).When(
                        !string.IsNullOrWhiteSpace(request.FilterDocumetnType),
                            q => q.WhereContains("document_type_code", request.FilterDocumetnType)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<ApplicantDocumentDto>(query);
                var result = new ApplicantDocumentItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    ApplicantDocumentList = data.ToList(),
                };
                return new NewApiResponse<ApplicantDocumentItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<ApplicantDocumentItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<NewApiResponse<ApplicantDocumentDto>> GetApplicantDocumentByCriteria(GetApplicantDocumentByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.ApplicantDocument)
                    .Select("applicant_no AS ApplicantNo",
                            "document_type_code AS DocumentTypeCode",
                            "file_path AS FilePath",
                            "remark AS Remark",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                        q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                    );
                var data = await db.FirstOrDefaultAsync<ApplicantDocumentDto>(query);
                
                return new NewApiResponse<ApplicantDocumentDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return new NewApiResponse<ApplicantDocumentDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<ApiResponse> SubmitApplicantDocument(SubmitApplicantDocumentCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                // Cek apakah data sudah ada berdasarkan ApplicantNo dan DocumentTypeCode
                var existingRecord = await db.Query(TableName.ApplicantDocument)
                    .Where("applicant_no", request.ApplicantNo)
                    .Where("document_type_code", request.DocumentTypeCode)
                    .FirstOrDefaultAsync();

                if (existingRecord == null)
                {
                    // Kondisi ADD (Insert)
                    var insertQuery = new Query(TableName.ApplicantDocument)
                        .AsInsert(new
                        {
                            applicant_no = request.ApplicantNo,
                            document_type_code = request.DocumentTypeCode,
                            file_path = request.FilePath,
                            remark = request.Remark,
                            inserted_by = "system",
                            inserted_date = DateTime.UtcNow,
                        });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                  
                }
                else
                {
                    // Kondisi EDIT (Update)
                    var updateQuery = new Query(TableName.ApplicantDocument)
                        .Where("applicant_no", request.ApplicantNo)
                        .Where("document_type_code", request.DocumentTypeCode)
                        .AsUpdate(new
                        {
                            file_path = request.FilePath,
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
        public async Task<ApiResponse> DeleteApplicantDocument(DeleteApplicantDocumentCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableName.ApplicantDocument)
                    .Where("applicant_no", request.ApplicantNo)
                    .Where("document_type_code", request.DocumentTypeCode)
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
