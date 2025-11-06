namespace ThePatho.Features.PersonalInformation.Employee.DTO
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set; }
        public string EmployeeNo { get; set; }
        public string Fullname { get; set; }
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public string JobClassCode { get; set; }
        public string JobClassName { get; set; }
        public string EmploymentTypeCode { get; set; }
        public string EmploymentTypeName { get; set; }
        public string WorkLocationCode { get; set; }
        public string WorkLocationName { get; set; }
        public string CostCenterCode { get; set; }
        public string CostCenterName { get; set; }
        public string JoinDate { get; set; }
        public string TerminateDate { get; set; }
        public string BirthPlace { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string TaxType { get; set; }
        public string TaxStatusCode { get; set; }
        public string NPWP { get; set; }
        public string AttendanceID { get; set; }
        public bool NeedReplacement { get; set; }
        public bool IsEligibleRehire { get; set; }
        public bool IsDeleted { get; set; }
        public string InsertedBy { get; set; }
        public string InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }

        // Personal data
        public int? NationalityID { get; set; }
        public string NationalityName { get; set; }
        public int? ReligionID { get; set; }
        public string ReligionName { get; set; }
        public string MaritalStatus { get; set; }
        public string MarriedDate { get; set; }
        public string BPJSTK { get; set; }
        public string BPJSKES { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string BloodType { get; set; }
        public string BloodTypeName { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string OfficePhone { get; set; }
        public string OfficeEmail { get; set; }
        public string BuildingCode { get; set; }
        public string BuildingName { get; set; }
        public string RoomCode { get; set; }
        public string RoomName { get; set; }
        public string PhotoPath { get; set; }
    }

    public class EmployeeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeDto> EmployeeList { get; set; } = new();
    }
}

