using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string? EmployeeNo { get; set; }
        public string CompanyCode { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string Fullname { get; set; } = null!;
        public string PositionCode { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string? BirthPlace { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? TerminateDate { get; set; }
        public DateTime? PermanentDate { get; set; }
        public DateTime? PensionDate { get; set; }
        public string JobClassCode { get; set; } = null!;
        public string EmploymentTypeCode { get; set; } = null!;
        public string CostCenterCode { get; set; } = null!;
        public string TaxType { get; set; } = null!;
        public string TaxStatusCode { get; set; } = null!;
        public string? NPWP { get; set; }
        public string? AttendanceID { get; set; }
        public bool IsDeleted { get; set; }
        public string? WorkLocationCode { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? TaxLocationID { get; set; }
        public bool NeedReplacement { get; set; }
        public string? BPJSTKLocation { get; set; }
        public string? BPJSKesLocation { get; set; }
        public byte? CapColorId { get; set; }
        public byte? PickUpId { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public int? JabatanId { get; set; }
        public bool IsEligibleRehire { get; set; }
        public int? FaskesId { get; set; }
    }

}

