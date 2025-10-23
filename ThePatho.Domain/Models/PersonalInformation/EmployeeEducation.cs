using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeeEducation
    {
        public int EmployeeID { get; set; }
        public string EduLevelCode { get; set; }
        public string Faculty { get; set; }
        public string MajorCode { get; set; }
        public DateTime? StartYear { get; set; }
        public DateTime? EndYear { get; set; }
        public string GPA { get; set; }
        public string MaxGPA { get; set; }
        public string Institution { get; set; }
        public string Address { get; set; }
        public string CityCode { get; set; }
        public string GradTypeCode { get; set; }
        public string CertificateNo { get; set; }
        public DateTime? CertificateDate { get; set; }
        public string Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int EmployeeEducationID { get; set; }
        public string OtherMajor { get; set; }
    }

}

