using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeAddress.Commands
{
    public class SubmitEmployeeAddressCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employeeid")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("companycode")]
        public string CompanyCode { get; set; } = null!;

        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;

        [JsonPropertyName("rt")]
        public string? Rt { get; set; }

        [JsonPropertyName("rw")]
        public string? Rw { get; set; }

        [JsonPropertyName("subdistrict")]
        public string? SubDistrict { get; set; }

        [JsonPropertyName("district")]
        public string? District { get; set; }

        [JsonPropertyName("cityid")]
        public string CityId { get; set; } = null!;

        [JsonPropertyName("provinceid")]
        public string ProvinceId { get; set; } = null!;

        [JsonPropertyName("countryid")]
        public string CountryId { get; set; } = null!;

        [JsonPropertyName("zipcode")]
        public string? ZipCode { get; set; }

        [JsonPropertyName("ownershipcode")]
        public string OwnershipCode { get; set; } = null!;

        [JsonPropertyName("curraddress")]
        public string CurrAddress { get; set; } = null!;

        [JsonPropertyName("currrt")]
        public string? CurrRt { get; set; }

        [JsonPropertyName("currrw")]
        public string? CurrRw { get; set; }

        [JsonPropertyName("currsubdistrict")]
        public string? CurrSubDistrict { get; set; }

        [JsonPropertyName("currdistrict")]
        public string? CurrDistrict { get; set; }

        [JsonPropertyName("currcityid")]
        public string CurrCityId { get; set; } = null!;

        [JsonPropertyName("currprovinceid")]
        public string CurrProvinceId { get; set; } = null!;

        [JsonPropertyName("currcountryid")]
        public string CurrCountryId { get; set; } = null!;

        [JsonPropertyName("currzipcode")]
        public string? CurrZipCode { get; set; }

        [JsonPropertyName("currownershipcode")]
        public string CurrOwnershipCode { get; set; } = null!;

        [JsonPropertyName("isdeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("insertedby")]
        public string? InsertedBy { get; set; }

        [JsonPropertyName("inserteddate")]
        public string? InsertedDate { get; set; }

        [JsonPropertyName("modifiedby")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("modifieddate")]
        public string? ModifiedDate { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

