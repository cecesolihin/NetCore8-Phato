using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeeInventory
    {
        public int EmployeeID { get; set; }
        public string InventoryNo { get; set; }
        public string InventoryTpyeCode { get; set; }
        public string InventoryName { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? ReturnPlanDate { get; set; }
        public short ReceivedQty { get; set; }
        public string Size { get; set; }
        public string ReceivedCondition { get; set; }
        public string ReceivedRemark { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string ReturnCondition { get; set; }
        public string ReturnRemark { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

