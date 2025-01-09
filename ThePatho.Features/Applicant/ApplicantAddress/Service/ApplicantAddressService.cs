using Microsoft.EntityFrameworkCore;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Features.Applicant.ApplicantAddress.Commands;
using ThePatho.Infrastructure.Persistance;
using SqlKata;

namespace ThePatho.Features.Applicant.ApplicantAddress.Service
{
    public class ApplicantAddressService : IApplicantAddressService
    {
        private readonly DapperContext dapperContext; 

        public ApplicantAddressService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<ApplicantAddressDto>> GetApplicantAddress(GetApplicantAddressCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantAddress)
                .Select("applicant_no AS ApplicantNo",
                        "address AS Address",
                        "rt AS RT",
                        "rw AS RW",
                        "sub_district AS SubDistrict",
                        "district AS District",
                        "city AS City",
                        "province AS Province",
                        "country AS Country",
                        "zip_code AS ZipCode",
                        "ownership AS Ownership",
                        "curr_address AS CurrentAddress",
                        "curr_rt AS CurrentRT",
                        "curr_rw AS CurrentRW",
                        "curr_sub_district AS CurrentSubDistrict",
                        "curr_district AS CurrentDistrict",
                        "curr_city AS CurrentCity",
                        "curr_province AS CurrentProvince",
                        "curr_country AS CurrentCountry",
                        "curr_zip_code AS CurrentZipCode",
                        "curr_ownership AS CurrentOwnership",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterAddress),
                        q => q.WhereContains("address", request.FilterAddress)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterCity),
                    q => q.WhereIn("city", request.FilterCity)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterProvince),
                        q => q.WhereContains("province", request.FilterProvince)
                 ).When(
                    !string.IsNullOrWhiteSpace(request.FilterCountry),
                        q => q.WhereContains("country", request.FilterCountry)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<ApplicantAddressDto>(query);
            return results.ToList();

        }

        public async Task<ApplicantAddressDto> GetApplicantAddressByCriteria(GetApplicantAddressByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.ApplicantAddress)
                .Select("applicant_no AS ApplicantNo",
                        "address AS Address",
                        "rt AS RT",
                        "rw AS RW",
                        "sub_district AS SubDistrict",
                        "district AS District",
                        "city AS City",
                        "province AS Province",
                        "country AS Country",
                        "zip_code AS ZipCode",
                        "ownership AS Ownership",
                        "curr_address AS CurrentAddress",
                        "curr_rt AS CurrentRT",
                        "curr_rw AS CurrentRW",
                        "curr_sub_district AS CurrentSubDistrict",
                        "curr_district AS CurrentDistrict",
                        "curr_city AS CurrentCity",
                        "curr_province AS CurrentProvince",
                        "curr_country AS CurrentCountry",
                        "curr_zip_code AS CurrentZipCode",
                        "curr_ownership AS CurrentOwnership",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate")
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterApplicantNo),
                    q => q.WhereIn("applicant_no", request.FilterApplicantNo)
                );
            var data = await db.FirstOrDefaultAsync<ApplicantAddressDto>(query);
            return data;
        }

        public async Task<bool> SubmitApplicantAddress(SubmitApplicantAddressCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            // Cek apakah data sudah ada berdasarkan ApplicantNo
            var existingRecord = await db.Query(TableName.ApplicantAddress)
                .Where("applicant_no", request.ApplicantNo)
                .FirstOrDefaultAsync();

            if (existingRecord == null)
            {
                // Kondisi ADD (Insert)
                var insertQuery = new Query(TableName.ApplicantAddress)
                    .AsInsert(new
                    {
                        applicant_no = request.ApplicantNo,
                        address = request.Address,
                        rt = request.RT,
                        rw = request.RW,
                        sub_district = request.SubDistrict,
                        district = request.District,
                        city = request.City,
                        province = request.Province,
                        country = request.Country,
                        zip_code = request.ZipCode,
                        ownership = request.Ownership,
                        curr_address = request.CurrentAddress,
                        curr_rt = request.CurrentRT,
                        curr_rw = request.CurrentRW,
                        curr_sub_district = request.CurrentSubDistrict,
                        curr_district = request.CurrentDistrict,
                        curr_city = request.CurrentCity,
                        curr_province = request.CurrentProvince,
                        curr_country = request.CurrentCountry,
                        curr_zip_code = request.CurrentZipCode,
                        curr_ownership = request.CurrentOwnership,
                        inserted_by =  "system",
                        inserted_date = DateTime.UtcNow,
                       
                    });

                var insertResult = await db.ExecuteAsync(insertQuery);
                return insertResult > 0;
            }
            else
            {
                // Kondisi EDIT (Update)
                var updateQuery = new Query(TableName.ApplicantAddress)
                    .Where("applicant_no", request.ApplicantNo)
                    .AsUpdate(new
                    {
                        address = request.Address,
                        rt = request.RT,
                        rw = request.RW,
                        sub_district = request.SubDistrict,
                        district = request.District,
                        city = request.City,
                        province = request.Province,
                        country = request.Country,
                        zip_code = request.ZipCode,
                        ownership = request.Ownership,
                        curr_address = request.CurrentAddress,
                        curr_rt = request.CurrentRT,
                        curr_rw = request.CurrentRW,
                        curr_sub_district = request.CurrentSubDistrict,
                        curr_district = request.CurrentDistrict,
                        curr_city = request.CurrentCity,
                        curr_province = request.CurrentProvince,
                        curr_country = request.CurrentCountry,
                        curr_zip_code = request.CurrentZipCode,
                        curr_ownership = request.CurrentOwnership,
                        modified_by =  "system",
                        modified_date = DateTime.UtcNow
                    });

                var updateResult = await db.ExecuteAsync(updateQuery);
                return updateResult > 0;
            }
        }


        public async Task<bool> DeleteApplicantAddress(DeleteApplicantAddressCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            var query = new Query(TableName.ApplicantAddress)
                .Where("applicant_no", request.ApplicantNo)
                .AsDelete();

            var affectedRows = await db.ExecuteAsync(query);
            return affectedRows > 0;
        }

    }
}
