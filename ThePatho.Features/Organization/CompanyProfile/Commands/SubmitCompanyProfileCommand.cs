using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.CompanyProfile.Commands
{
    public class SubmitCompanyProfileCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("company_code")]
        public string CompanyCode { get; set; } = null!;

        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; } = null!;

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("fax")]
        public string? Fax { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("comp_tax_no")]
        public string? CompTaxNo { get; set; }

        [JsonPropertyName("bpjs_tk_card_no")]
        public string? BpjsTkCardNo { get; set; }

        [JsonPropertyName("bpjs_tk_reg_no")]
        public string? BpjsTkRegNo { get; set; }

        [JsonPropertyName("bpjs_ks_card_no")]
        public string? BpjsKsCardNo { get; set; }

        [JsonPropertyName("bpjs_ks_reg_no")]
        public string? BpjsKsRegNo { get; set; }

        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; } = null!;

        [JsonPropertyName("main_business")]
        public string? MainBusiness { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("zip_code")]
        public string? ZipCode { get; set; }

        [JsonPropertyName("logo")]
        public byte[]? Logo { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("tax_penalty_by_emp")]
        public int? TaxPenaltyByEmp { get; set; }

        [JsonPropertyName("tax_penalty_by_comp")]
        public int? TaxPenaltyByComp { get; set; }

        [JsonPropertyName("tax_location_id")]
        public int? TaxLocationId { get; set; }

        [JsonPropertyName("inserted_by")]
        public string? InsertedBy { get; set; }

        [JsonPropertyName("inserted_date")]
        public string? InsertedDate { get; set; }

        [JsonPropertyName("modified_by")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("modified_date")]
        public string? ModifiedDate { get; set; }

        [JsonPropertyName("general_settings_config_guid")]
        public string? GeneralSettingsConfigGuid { get; set; }

        [JsonPropertyName("bpjstk_location")]
        public string? BpjstkLocation { get; set; }

        [JsonPropertyName("bpjskes_location")]
        public string? BpjskesLocation { get; set; }

        [JsonPropertyName("phone_upin")]
        public string? PhoneUpin { get; set; }

        [JsonPropertyName("fax_upin")]
        public string? FaxUpin { get; set; }

        [JsonPropertyName("email_upin")]
        public string? EmailUpin { get; set; }

        [JsonPropertyName("abbreviation_upin")]
        public string AbbreviationUpin { get; set; } = null!;

        [JsonPropertyName("main_business_upin")]
        public string? MainBusinessUpin { get; set; }

        [JsonPropertyName("address_upin")]
        public string? AddressUpin { get; set; }

        [JsonPropertyName("zip_code_upin")]
        public string? ZipCodeUpin { get; set; }

        [JsonPropertyName("city_upin")]
        public string? CityUpin { get; set; }

        [JsonPropertyName("country_code_upin")]
        public string? CountryCodeUpin { get; set; }

        [JsonPropertyName("checked_by_id")]
        public int? CheckedById { get; set; }

        [JsonPropertyName("approved1_id")]
        public int? Approved1Id { get; set; }

        [JsonPropertyName("approved2_id")]
        public int? Approved2Id { get; set; }

        [JsonPropertyName("prepared_id")]
        public int? PreparedId { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
