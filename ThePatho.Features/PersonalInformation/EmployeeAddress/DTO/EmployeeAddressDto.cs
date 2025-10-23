namespace ThePatho.Features.PersonalInformation.EmployeeAddress.DTO
{
    public class EmployeeAddressDto
    {
        public int EmployeeId { get; set; }
        public string CompanyCode { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Rt { get; set; }
        public string? Rw { get; set; }
        public string? SubDistrict { get; set; }
        public string? District { get; set; }
        public string CityId { get; set; } = null!;
        public string ProvinceId { get; set; } = null!;
        public string CountryId { get; set; } = null!;
        public string? ZipCode { get; set; }
        public string OwnershipCode { get; set; } = null!;
        public string CurrAddress { get; set; } = null!;
        public string? CurrRt { get; set; }
        public string? CurrRw { get; set; }
        public string? CurrSubDistrict { get; set; }
        public string? CurrDistrict { get; set; }
        public string CurrCityId { get; set; } = null!;
        public string CurrProvinceId { get; set; } = null!;
        public string CurrCountryId { get; set; } = null!;
        public string? CurrZipCode { get; set; }
        public string CurrOwnershipCode { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class EmployeeAddressItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeAddressDto> EmployeeAddressList { get; set; } = new();
    }
}

