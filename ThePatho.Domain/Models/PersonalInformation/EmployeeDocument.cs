using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeeDocument
    {
        public int EmployeeDocumentId { get; set; }
        public int EmployeeID { get; set; }
        public string DocumentTypeCode { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public string? Remark { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}

