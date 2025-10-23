using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeeSetPickUp
    {
        public Guid PickupID { get; set; }
        public DateTime Date { get; set; }
        public string PickUpType { get; set; } = null!;
        public string RouteCode { get; set; } = null!;
        public TimeSpan PlanOut { get; set; }
        public decimal ToleranceBefore { get; set; }
        public decimal ToleranceAfter { get; set; }
        public TimeSpan DepartTime { get; set; }
        public TimeSpan ArriveTime { get; set; }
        public int TotalEmployee { get; set; }
        public int Capacity { get; set; }
        public string? BusCode { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}

