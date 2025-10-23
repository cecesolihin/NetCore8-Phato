namespace ThePatho.Features.PersonalInformation.EmployeeTraining.DTO
{
    public class EmployeeTrainingDto
    {
        public int EmpTrainingId { get; set; }
        public int EmployeeId { get; set; }
        public string TrainingCourseCode { get; set; } = null!;
        public string StartDate { get; set; } = null!;
        public string TrainingTypeCode { get; set; } = null!;
        public string TrainingFieldCode { get; set; } = null!;
        public string Institution { get; set; } = null!;
        public string? Address { get; set; }
        public string CityCode { get; set; } = null!;
        public string? CertificateNo { get; set; }
        public string? CertificateDate { get; set; }
        public string? EndDate { get; set; }
        public string TrainingPayerCode { get; set; } = null!;
        public string? CompanyBondDate { get; set; }
        public string? Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? TrainingBatchCode { get; set; }
    }

    public class EmployeeTrainingItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeTrainingDto> EmployeeTrainingList { get; set; } = new();
    }
}

