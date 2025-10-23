using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeeIdentity
    {
        public int EmployeeID { get; set; }
        public string IdentityCode { get; set; }
        public string CompanyCode { get; set; }
        public string IdentityNo { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public byte[] FileUpload { get; set; }
        public string Remarks { get; set; }
        public string FileFullPath { get; set; }
        public string FileName { get; set; }
        public bool IsDeleted { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

