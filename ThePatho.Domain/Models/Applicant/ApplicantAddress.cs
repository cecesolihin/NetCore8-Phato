using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Applicant
{
    public class ApplicantAddress
    {
        public string ApplicantNo { get; set; }
        public string Address { get; set; }
        public string RT { get; set; }
        public string RW { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Ownership { get; set; }
        public string CurrAddress { get; set; }
        public string CurrRT { get; set; }
        public string CurrRW { get; set; }
        public string CurrSubDistrict { get; set; }
        public string CurrDistrict { get; set; }
        public string CurrCity { get; set; }
        public string CurrProvince { get; set; }
        public string CurrCountry { get; set; }
        public string CurrZipCode { get; set; }
        public string CurrOwnership { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}
