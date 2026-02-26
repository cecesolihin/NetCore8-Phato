using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.CompanyProfile.Commands
{
    public class SubmitCompanyProfileCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("companyCode")]
        public string CompanyCode { get; set; } = null!;

        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; } = null!;

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("fax")]
        public string? Fax { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("compTaxNo")]
        public string? CompTaxNo { get; set; }

        [JsonPropertyName("bpjsTkCardNo")]
        public string? BpjsTkCardNo { get; set; }

        [JsonPropertyName("bpjsTkRegNo")]
        public string? BpjsTkRegNo { get; set; }

        [JsonPropertyName("bpjsKsCardNo")]
        public string? BpjsKsCardNo { get; set; }

        [JsonPropertyName("bpjsKsRegNo")]
        public string? BpjsKsRegNo { get; set; }

        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; } = null!;

        [JsonPropertyName("mainBusiness")]
        public string? MainBusiness { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("zipCode")]
        public string? ZipCode { get; set; }

        [JsonPropertyName("logo")]
        public byte[]? Logo { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("countryCode")]
        public string? CountryCode { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("taxPenaltyByEmp")]
        public int? TaxPenaltyByEmp { get; set; }

        [JsonPropertyName("taxPenaltyByComp")]
        public int? TaxPenaltyByComp { get; set; }

        [JsonPropertyName("taxLocationId")]
        public int? TaxLocationId { get; set; }

        [JsonPropertyName("insertedBy")]
        public string? InsertedBy { get; set; }

        [JsonPropertyName("insertedDate")]
        public string? InsertedDate { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("modifiedDate")]
        public string? ModifiedDate { get; set; }

        [JsonPropertyName("generalSettingsConfigGuid")]
        public string? GeneralSettingsConfigGuid { get; set; }

        [JsonPropertyName("bpjstkLocation")]
        public string? BpjstkLocation { get; set; }

        [JsonPropertyName("bpjskesLocation")]
        public string? BpjskesLocation { get; set; }

        [JsonPropertyName("phoneUpin")]
        public string? PhoneUpin { get; set; }

        [JsonPropertyName("faxUpin")]
        public string? FaxUpin { get; set; }

        [JsonPropertyName("emailUpin")]
        public string? EmailUpin { get; set; }

        [JsonPropertyName("abbreviationUpin")]
        public string AbbreviationUpin { get; set; } = null!;

        [JsonPropertyName("mainBusinessUpin")]
        public string? MainBusinessUpin { get; set; }

        [JsonPropertyName("addressUpin")]
        public string? AddressUpin { get; set; }

        [JsonPropertyName("zipCodeUpin")]
        public string? ZipCodeUpin { get; set; }

        [JsonPropertyName("cityUpin")]
        public string? CityUpin { get; set; }

        [JsonPropertyName("countryCodeUpin")]
        public string? CountryCodeUpin { get; set; }

        [JsonPropertyName("checkedById")]
        public int? CheckedById { get; set; }

        [JsonPropertyName("approved1Id")]
        public int? Approved1Id { get; set; }

        [JsonPropertyName("approved2Id")]
        public int? Approved2Id { get; set; }

        [JsonPropertyName("preparedId")]
        public int? PreparedId { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
