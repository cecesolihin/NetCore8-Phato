using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Organization
{
    public class CompanyBank
    {
        public int CompanyBankId { get; set; }
        public string? CompanyCode { get; set; }
        public string? BankCode { get; set; }
        public string Branch { get; set; } = null!;
        public string? AccountNo { get; set; }
        public string? AccountName { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsDefault { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
