using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeAddress.Commands;
using ThePatho.Features.PersonalInformation.EmployeeAddress.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeAddress.Service
{
    public class EmployeeAddressService : IEmployeeAddressService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        #endregion

        #region [CTOR]
        public EmployeeAddressService(DapperContext _dapperContext, SqlQueryLoader _queryLoader)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
        }
        #endregion

        #region [METHODS]
   
        public async Task<ApiResponse<EmployeeAddressDto>> GetSingleEmployeeAddress(GetSingleEmployeeAddressCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeAddress/Sql/get_single_emp_address");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeAddressDto>(query, parameters);

                return new ApiResponse<EmployeeAddressDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeAddressDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Address detail.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeAddress(SubmitEmployeeAddressCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@CompanyCode", request.CompanyCode);
                parameters.Add("@Address", request.Address);
                parameters.Add("@Rt", request.Rt);
                parameters.Add("@Rw", request.Rw);
                parameters.Add("@SubDistrict", request.SubDistrict);
                parameters.Add("@District", request.District);
                parameters.Add("@CityId", request.CityId);
                parameters.Add("@ProvinceId", request.ProvinceId);
                parameters.Add("@CountryId", request.CountryId);
                parameters.Add("@ZipCode", request.ZipCode);
                parameters.Add("@OwnershipCode", request.OwnershipCode);
                parameters.Add("@CurrAddress", request.CurrAddress);
                parameters.Add("@CurrRt", request.CurrRt);
                parameters.Add("@CurrRw", request.CurrRw);
                parameters.Add("@CurrSubDistrict", request.CurrSubDistrict);
                parameters.Add("@CurrDistrict", request.CurrDistrict);
                parameters.Add("@CurrCityId", request.CurrCityId);
                parameters.Add("@CurrProvinceId", request.CurrProvinceId);
                parameters.Add("@CurrCountryId", request.CurrCountryId);
                parameters.Add("@CurrZipCode", request.CurrZipCode);
                parameters.Add("@CurrOwnershipCode", request.CurrOwnershipCode);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@InsertedBy", request.InsertedBy);
                parameters.Add("@InsertedDate", request.InsertedDate);
                parameters.Add("@ModifiedBy", request.ModifiedBy);
                parameters.Add("@ModifiedDate", request.ModifiedDate);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeAddress/Sql/submit_emp_address");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        #endregion
    }
}

