using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeeMedical
    {
        public int EmployeeID { get; set; }
        public string DiseaseCategoryCode { get; set; }
        public string DiseaseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Therapy { get; set; }
        public string Hospital { get; set; }
        public string CountryId { get; set; }
        public string ProvinceId { get; set; }
        public string CityCode { get; set; }
        public string Doctor { get; set; }
        public string Phone { get; set; }
        public string Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public string Obat { get; set; }
        public string TindakanPertama { get; set; }
        public string TindakanKedua { get; set; }
    }
}

