using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Features.Applicant.ApplicantPersonalData.Commands;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Features.Applicant.ApplicantPersonalData.Service;
using ThePatho.Provider.ApiResponse;
using ThePatho.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Service
{
    public class ApplicantPersonalDataService : IApplicantPersonalDataService
    {
        private readonly DapperContext dapperContext; 

        public ApplicantPersonalDataService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<ApiResponse<ApplicantPersonalDataItemDto>> GetApplicantPersonalData(GetApplicantPersonalDataCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.ApplicantPersonalData)
                    .Select("applicant_no AS ApplicantNo",
                            "nationality_id AS NationalityId",
                            "religion_id AS ReligionId",
                            "marital_status AS MaritalStatus",
                            "married_date AS MarriedDate",
                            "nick_name AS NickName",
                            "phone AS Phone",
                            "mobile_phone AS MobilePhone",
                            "email AS Email",
                            "blood_type AS BloodType",
                            "height AS Height",
                            "weight AS Weight",
                            "photo AS Photo",
                            "reference AS Reference",
                            "emergency_contact_name AS EmergencyContactName",
                            "emergency_contact AS EmergencyContact",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                        q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterNationalId),
                            q => q.WhereContains("nationality_id", request.FilterNationalId)
                    ).When(
                        !string.IsNullOrWhiteSpace(request.FilterReligionId),
                        q => q.WhereIn("religion_id", request.FilterReligionId)
                     ).When(
                        !string.IsNullOrWhiteSpace(request.FilterMaritalStatus),
                            q => q.WhereContains("marital_status", request.FilterMaritalStatus)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<ApplicantPersonalDataDto>(query);
                var result = new ApplicantPersonalDataItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    ApplicantPersonalDataList = data.ToList(),
                };
                return new ApiResponse<ApplicantPersonalDataItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                return new ApiResponse<ApplicantPersonalDataItemDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<ApiResponse<ApplicantPersonalDataDto>> GetApplicantPersonalDataByCriteria(GetApplicantPersonalDataByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableName.ApplicantPersonalData)
                    .Select("applicant_no AS ApplicantNo",
                            "nationality_id AS NationalityId",
                            "religion_id AS ReligionId",
                            "marital_status AS MaritalStatus",
                            "married_date AS MarriedDate",
                            "nick_name AS NickName",
                            "phone AS Phone",
                            "mobile_phone AS MobilePhone",
                            "email AS Email",
                            "blood_type AS BloodType",
                            "height AS Height",
                            "weight AS Weight",
                            "photo AS Photo",
                            "reference AS Reference",
                            "emergency_contact_name AS EmergencyContactName",
                            "emergency_contact AS EmergencyContact",
                            "inserted_by AS InsertedBy",
                            "inserted_date AS InsertedDate",
                            "modified_by AS ModifiedBy",
                            "modified_date AS ModifiedDate")
                    .When(
                        !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                        q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                    );
                var data = await db.FirstOrDefaultAsync<ApplicantPersonalDataDto>(query);
                
                return new ApiResponse<ApplicantPersonalDataDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return new ApiResponse<ApplicantPersonalDataDto>(
                        HttpStatusCode.BadRequest,
                        "An error occurred while retrieving data.",
                        ex.Message
                    );
            }
        }

        public async Task<ApiResponse> SubmitApplicantPersonalData(SubmitApplicantPersonalDataCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                if (string.IsNullOrWhiteSpace(request.ApplicantNo))
                {
                    throw new ArgumentException("ApplicantNo is required.");
                }

                // Check if data exists
                var existsQuery = new Query(TableName.ApplicantPersonalData)
                    .Where("applicant_no", request.ApplicantNo)
                    .SelectRaw("COUNT(1)");

                var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                if (exists == 0)
                {
                    // Kondisi ADD (Insert)
                    var insertQuery = new Query(TableName.ApplicantPersonalData).AsInsert(new
                    {
                        applicant_no = request.ApplicantNo,
                        nationality_id = request.NationalityId,
                        religion_id = request.ReligionId,
                        marital_status = request.MaritalStatus,
                        married_date = request.MarriedDate,
                        nick_name = request.NickName,
                        phone = request.Phone,
                        mobile_phone = request.MobilePhone,
                        email = request.Email,
                        blood_type = request.BloodType,
                        height = request.Height,
                        weight = request.Weight,
                        photo = request.Photo,
                        reference = request.Reference,
                        emergency_contact_name = request.EmergencyContactName,
                        emergency_contact = request.EmergencyContact,
                        inserted_by = "system",
                        inserted_date = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                  
                }
                else
                {
                    // Kondisi EDIT (Update)
                    var updateQuery = new Query(TableName.ApplicantPersonalData)
                        .Where("applicant_no", request.ApplicantNo)
                        .AsUpdate(new
                        {
                            nationality_id = request.NationalityId,
                            religion_id = request.ReligionId,
                            marital_status = request.MaritalStatus,
                            married_date = request.MarriedDate,
                            nick_name = request.NickName,
                            phone = request.Phone,
                            mobile_phone = request.MobilePhone,
                            email = request.Email,
                            blood_type = request.BloodType,
                            height = request.Height,
                            weight = request.Weight,
                            photo = request.Photo,
                            reference = request.Reference,
                            emergency_contact_name = request.EmergencyContactName,
                            emergency_contact = request.EmergencyContact,
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
        public async Task<ApiResponse> DeleteApplicantPersonalData(DeleteApplicantPersonalDataCommand request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.ApplicantNo))
                    throw new ArgumentException("ApplicantNo is required.");

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableName.ApplicantPersonalData)
                    .Where("applicant_no", request.ApplicantNo)
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
