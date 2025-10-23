using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeePunishment
    {
        public int EmPunishmentID { get; set; }
        public string LetterNo { get; set; }
        public int EmployeeID { get; set; }
        public DateTime LetterDate { get; set; }
        public string PunishmentType { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime? RecoveryDate { get; set; }
        public string Remarks { get; set; }
        public bool? IsDeleted { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Attachment { get; set; }
    }

}

