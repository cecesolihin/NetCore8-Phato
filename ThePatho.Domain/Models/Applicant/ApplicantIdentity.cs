using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Applicant
{
    public class ApplicantIdentity
    {
        public string ApplicantNo { get; set; }
        public string IdentityCode { get; set; }
        public string IdentityNo { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public byte[] FileUpload { get; set; }
        public string Remark { get; set; }
        public string FileFullPath { get; set; }
        public string FileName { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
