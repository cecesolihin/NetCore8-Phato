using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeeLoan
    {
        public int EmpLoanID { get; set; }
        public int EmployeeID { get; set; }
        public string? LoanTypeCode { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime LoanDate { get; set; }
        public string? StatusCode { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}

