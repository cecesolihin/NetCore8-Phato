using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeeFamily
    {
        public int EmployeeID { get; set; }
        public string RelationCode { get; set; }
        public string FamilyName { get; set; }
        public string Gender { get; set; }
        public string BirthPlace { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string BloodTypeCode { get; set; }
        public string EduLevelCode { get; set; }
        public string MaritalStatusCode { get; set; }
        public string DependentStatus { get; set; }
        public bool EmergencyContact { get; set; }
        public bool? WorkingStatus { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string KKNo { get; set; }
        public string IdentityNo { get; set; }
        public string BPJSNo { get; set; }
        public string InsuranceName { get; set; }
        public string PolisNo { get; set; }
        public string Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int EmployeeFamilyID { get; set; }
        public bool? VitalStatus { get; set; }
    }

}

