using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.PersonalInformation
{
    public class EmployeePersonalData
    {
        public int EmployeeID { get; set; }
        public string CompanyCode { get; set; }
        public int? NationalityID { get; set; }
        public int? ReligionID { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime? MarriedDate { get; set; }
        public string BPJSTK { get; set; }
        public string BPJSKES { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string BloodType { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string OfficePhone { get; set; }
        public string OfficeEmail { get; set; }
        public string BuildingCode { get; set; }
        public string RoomCode { get; set; }
        public string ComputerName { get; set; }
        public string StaticIPAddress { get; set; }
        public bool? Glasses { get; set; }
        public string LeftEye { get; set; }
        public string RightEye { get; set; }
        public string Hat { get; set; }
        public string Helmet { get; set; }
        public string Clothes { get; set; }
        public string Jacket { get; set; }
        public string Pants { get; set; }
        public string Shoes { get; set; }
        public string Boots { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] Photo { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool SeverancePaid { get; set; }
        public DateTime? SeverancePaidDate { get; set; }
        public string RFID { get; set; }
        public string Recruiter { get; set; }
        public string HireOrigin { get; set; }
        public string PayGroup { get; set; }
        public string PhotoPath { get; set; }
        public bool StatusIDCard { get; set; }
        public bool IsDonate { get; set; }
    }
}

