namespace ThePatho.Features.PersonalInformation.EmployeeMedical.DTO
{
    public class EmployeeMedicalDto
    {
        public int EmployeeId { get; set; }
        public string? EmployeeNo { get; set; }
        public string? EmployeeName { get; set; }
        public string? PositionName { get; set; }
        public string? JobLevelName { get; set; }
        public string? CompanyName { get; set; }
        public string DiseaseCategoryCode { get; set; } 
        public string DiseaseName { get; set; } 
        public string StartDate { get; set; } 
        public string EndDate { get; set; } 
        public string Therapy { get; set; } 
        public string Hospital { get; set; } 
        public string CountryId { get; set; } 
        public string ProvinceId { get; set; } 
        public string CityCode { get; set; } 
        public string Doctor { get; set; } 
        public string Phone { get; set; } 
        public string Remarks { get; set; } 
        public bool IsDeleted { get; set; }
        public string InsertedBy { get; set; } 
        public string? InsertedDate { get; set; }
        public string ModifiedBy { get; set; } 
        public string? ModifiedDate { get; set; }
        public string? TimeIn { get; set; }
        public string? TimeOut { get; set; }
        public string Obat { get; set; } 
        public string TindakanPertama { get; set; } 
        public string TindakanKedua { get; set; } 
    }

    public class EmployeeMedicalItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeMedicalDto> EmployeeMedicalList { get; set; } = new();
    }
}

