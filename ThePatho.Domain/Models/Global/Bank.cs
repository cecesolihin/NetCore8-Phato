using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Global
{
    public class Bank
    {
        public string BankCode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string CurrencyCode { get; set; } = null!;
        public string? TransferCode { get; set; }
        public decimal? TransdferFee { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? BranchName { get; set; }
        public string? SwiftCode { get; set; }
    }
}
