using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeAddress.Commands
{
    public class SubmitEmployeeAddressCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("company_code")]
        public string CompanyCode { get; set; } = null!;

        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;

        [JsonPropertyName("rt")]
        public string? Rt { get; set; }

        [JsonPropertyName("rw")]
        public string? Rw { get; set; }

        [JsonPropertyName("sub_district")]
        public string? SubDistrict { get; set; }

        [JsonPropertyName("district")]
        public string? District { get; set; }

        [JsonPropertyName("city_id")]
        public string CityId { get; set; } = null!;

        [JsonPropertyName("province_id")]
        public string ProvinceId { get; set; } = null!;

        [JsonPropertyName("country_id")]
        public string CountryId { get; set; } = null!;

        [JsonPropertyName("zip_code")]
        public string? ZipCode { get; set; }

        [JsonPropertyName("ownership_code")]
        public string OwnershipCode { get; set; } = null!;

        [JsonPropertyName("curr_address")]
        public string CurrAddress { get; set; } = null!;

        [JsonPropertyName("curr_rt")]
        public string? CurrRt { get; set; }

        [JsonPropertyName("curr_rw")]
        public string? CurrRw { get; set; }

        [JsonPropertyName("curr_sub_district")]
        public string? CurrSubDistrict { get; set; }

        [JsonPropertyName("curr_district")]
        public string? CurrDistrict { get; set; }

        [JsonPropertyName("curr_city_id")]
        public string CurrCityId { get; set; } = null!;

        [JsonPropertyName("curr_province_id")]
        public string CurrProvinceId { get; set; } = null!;

        [JsonPropertyName("curr_country_id")]
        public string CurrCountryId { get; set; } = null!;

        [JsonPropertyName("curr_zip_code")]
        public string? CurrZipCode { get; set; }

        [JsonPropertyName("curr_ownership_code")]
        public string CurrOwnershipCode { get; set; } = null!;

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("inserted_by")]
        public string? InsertedBy { get; set; }

        [JsonPropertyName("inserted_date")]
        public string? InsertedDate { get; set; }

        [JsonPropertyName("modified_by")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("modified_date")]
        public string? ModifiedDate { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

