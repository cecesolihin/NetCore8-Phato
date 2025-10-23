using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeeAddress
    {
        public int EmployeeID { get; set; }
        public string CompanyCode { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? RT { get; set; }
        public string? RW { get; set; }
        public string? SubDistrict { get; set; }
        public string? District { get; set; }
        public string CityId { get; set; } = null!;
        public string ProvinceId { get; set; } = null!;
        public string CountryId { get; set; } = null!;
        public string? ZipCode { get; set; }
        public string OwnershipCode { get; set; } = null!;
        public string CurrAddress { get; set; } = null!;
        public string? CurrRT { get; set; }
        public string? CurrRW { get; set; }
        public string? CurrSubDistrict { get; set; }
        public string? CurrDistrict { get; set; }
        public string CurrCityId { get; set; } = null!;
        public string CurrProvinceId { get; set; } = null!;
        public string CurrCountryId { get; set; } = null!;
        public string? CurrZipCode { get; set; }
        public string CurrOwnershipCode { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}

