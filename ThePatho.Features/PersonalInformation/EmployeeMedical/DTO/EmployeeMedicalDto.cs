namespace ThePatho.Features.PersonalInformation.EmployeeMedical.DTO
{
    public class EmployeeMedicalDto
    {
        public int EmployeeId { get; set; }
        public string DiseaseCategoryCode { get; set; } = null!;
        public string DiseaseName { get; set; } = null!;
        public string StartDate { get; set; } = null!;
        public string EndDate { get; set; } = null!;
        public string Therapy { get; set; } = null!;
        public string Hospital { get; set; } = null!;
        public string CountryId { get; set; } = null!;
        public string ProvinceId { get; set; } = null!;
        public string CityCode { get; set; } = null!;
        public string Doctor { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Remarks { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string InsertedBy { get; set; } = null!;
        public string? InsertedDate { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public string? ModifiedDate { get; set; }
        public string? TimeIn { get; set; }
        public string? TimeOut { get; set; }
        public string Obat { get; set; } = null!;
        public string TindakanPertama { get; set; } = null!;
        public string TindakanKedua { get; set; } = null!;
    }

    public class EmployeeMedicalItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeMedicalDto> EmployeeMedicalList { get; set; } = new();
    }
}

