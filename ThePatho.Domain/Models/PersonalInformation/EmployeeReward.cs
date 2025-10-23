using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeeReward
    {
        public int EmRewardID { get; set; }
        public string LetterNo { get; set; } = null!;
        public int EmployeeID { get; set; }
        public DateTime LetterDate { get; set; }
        public string RewardTypeCode { get; set; } = null!;
        public string? Remarks { get; set; }
        public string CurrencyCode { get; set; } = null!;
        public decimal? Amount { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Attachment { get; set; }
    }

}

