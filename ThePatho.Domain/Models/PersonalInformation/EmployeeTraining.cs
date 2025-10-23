using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeeTraining
    {
        public int EmpTrainingId { get; set; }
        public int EmployeeID { get; set; } 
        public string TrainingCourseCode { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public string TrainingTypeCode { get; set; } = null!;
        public string TrainingFieldCode { get; set; } = null!;
        public string Institution { get; set; } = null!;
        public string? Address { get; set; }
        public int? CityId { get; set; } = null!;
        public string? CertificateNo { get; set; }
        public DateTime? CertificateDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string TrainingPayerCode { get; set; } = null!;
        public DateTime? CompanyBondDate { get; set; }
        public string? Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? TrainingBatchCode { get; set; }
    }

}

