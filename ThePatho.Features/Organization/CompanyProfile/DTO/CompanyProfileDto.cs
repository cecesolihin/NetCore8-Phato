namespace ThePatho.Features.Organization.CompanyProfile.DTO
{
    public class CompanyProfileDto
    {
        public string CompanyCode { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? CompTaxNo { get; set; }
        public string? BpjsTkCardNo { get; set; }
        public string? BpjsTkRegNo { get; set; }
        public string? BpjsKsCardNo { get; set; }
        public string? BpjsKsRegNo { get; set; }
        public string Abbreviation { get; set; } = null!;
        public string? MainBusiness { get; set; }
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public byte[]? Logo { get; set; }
        public string? City { get; set; }
        public string? CountryCode { get; set; }
        public bool IsDeleted { get; set; }
        public int? TaxPenaltyByEmp { get; set; }
        public int? TaxPenaltyByComp { get; set; }
        public int? TaxLocationId { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? GeneralSettingsConfigGuid { get; set; }
        public string? BpjstkLocation { get; set; }
        public string? BpjskesLocation { get; set; }
        public string? PhoneUpin { get; set; }
        public string? FaxUpin { get; set; }
        public string? EmailUpin { get; set; }
        public string AbbreviationUpin { get; set; } = null!;
        public string? MainBusinessUpin { get; set; }
        public string? AddressUpin { get; set; }
        public string? ZipCodeUpin { get; set; }
        public string? CityUpin { get; set; }
        public string? CountryCodeUpin { get; set; }
        public int? CheckedById { get; set; }
        public int? Approved1Id { get; set; }
        public int? Approved2Id { get; set; }
        public int? PreparedId { get; set; }
    }

    public class CompanyProfileItemDto
    {
        public int DataOfRecords { get; set; }
        public List<CompanyProfileDto> CompanyProfileList { get; set; } = new();
    }
}
