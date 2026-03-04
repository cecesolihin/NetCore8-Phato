namespace ThePatho.Features.PersonalInformation.EmployeeTraining.DTO
{
    public class EmployeeTrainingDto
    {
        public int EmpTrainingId { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeNo { get; set; }
        public string? EmployeeName { get; set; }
        public string? PositionName { get; set; }
        public string? JobLevelName { get; set; }
        public string? CompanyName { get; set; }
        public string TrainingCourseCode { get; set; } 
        public string StartDate { get; set; } 
        public string TrainingTypeCode { get; set; } 
        public string TrainingFieldCode { get; set; } 
        public string Institution { get; set; } 
        public string? Address { get; set; }
        public string CityCode { get; set; } 
        public string? CertificateNo { get; set; }
        public string? CertificateDate { get; set; }
        public string? EndDate { get; set; }
        public string TrainingPayerCode { get; set; } 
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

