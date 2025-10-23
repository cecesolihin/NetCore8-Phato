using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Organization
{
    public class CompanyProfile
    {
        public string CompanyCode { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? CompTaxNo { get; set; }
        public string? BpjsTKCardNo { get; set; }
        public string? BpjsTKRegNo { get; set; }
        public string? BpjsKSCardNo { get; set; }
        public string? BpjsKSRegNo { get; set; }
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
        public int? TaxLocationID { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? GeneralSettings_ConfigGuid { get; set; }
        public string? BPJSTKLocation { get; set; }
        public string? BPJSKesLocation { get; set; }
        public string? Phone_UPIN { get; set; }
        public string? Fax_UPIN { get; set; }
        public string? Email_UPIN { get; set; }
        public string Abbreviation_UPIN { get; set; } = null!;
        public string? MainBusiness_UPIN { get; set; }
        public string? Address_UPIN { get; set; }
        public string? ZipCode_UPIN { get; set; }
        public string? City_UPIN { get; set; }
        public string? CountryCode_UPIN { get; set; }
        public int? CheckedById { get; set; }
        public int? Approved1Id { get; set; }
        public int? Approved2Id { get; set; }
        public int? PreparedId { get; set; }
    }
}
