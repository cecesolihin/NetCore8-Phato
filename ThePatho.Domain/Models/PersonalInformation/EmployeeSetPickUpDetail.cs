using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeeSetPickUpDetail
    {
        public Guid EmployeeSetPickUpDetailId { get; set; }
        public Guid PickupID { get; set; }
        public int EmployeeId { get; set; }
        public string LocationCode { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}

