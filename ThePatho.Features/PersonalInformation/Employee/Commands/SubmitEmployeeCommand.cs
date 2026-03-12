using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.Employee.Commands
{
    public class SubmitEmployeeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employeeId")]
        public int? EmployeeId { get; set; }

        [JsonPropertyName("employeeNo")]
        public string? EmployeeNo { get; set; }

        [JsonPropertyName("companyCode")]
        public string CompanyCode { get; set; }

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("middleName")]
        public string? MiddleName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("fullName")]
        public string Fullname { get; set; } = null!;

        [JsonPropertyName("gender")]
        public string Gender { get; set; } = null!;

        [JsonPropertyName("birthPlace")]
        public string? BirthPlace { get; set; }

        [JsonPropertyName("birthDate")]
        public DateTime? BirthDate { get; set; }

        [JsonPropertyName("joinDate")]
        public DateTime? JoinDate { get; set; }

        [JsonPropertyName("terminateDate")]
        public DateTime? TerminateDate { get; set; }

        [JsonPropertyName("permanentDate")]
        public DateTime? PermanentDate { get; set; }

        [JsonPropertyName("pensionDate")]
        public DateTime? PensionDate { get; set; }

        [JsonPropertyName("contractEndDate")]
        public DateTime? ContractEndDate { get; set; }

        [JsonPropertyName("positionCode")]
        public string PositionCode { get; set; } = null!;

        [JsonPropertyName("jobClassCode")]
        public string JobClassCode { get; set; } = null!;

        [JsonPropertyName("employmentTypeCode")]
        public string EmploymentTypeCode { get; set; } = null!;

        [JsonPropertyName("costCenterCode")]
        public string CostCenterCode { get; set; } = null!;

        [JsonPropertyName("workLocationCode")]
        public string? WorkLocationCode { get; set; }

        [JsonPropertyName("jabatanId")]
        public int? JabatanId { get; set; }

        [JsonPropertyName("isEligibleRehire")]
        public bool? IsEligibleRehire { get; set; }

        [JsonPropertyName("taxType")]
        public string TaxType { get; set; } = null!;

        [JsonPropertyName("taxStatusCode")]
        public string TaxStatusCode { get; set; } = null!;

        [JsonPropertyName("npwp")]
        public string? Npwp { get; set; }

        [JsonPropertyName("taxLocationId")]
        public int? TaxLocationId { get; set; }

        [JsonPropertyName("needReplacement")]
        public bool? NeedReplacement { get; set; }

        [JsonPropertyName("payGroup")]
        public string? PayGroup { get; set; }

        [JsonPropertyName("nationalityId")]
        public int? NationalityId { get; set; }

        [JsonPropertyName("religionId")]
        public int? ReligionId { get; set; }

        [JsonPropertyName("maritalStatus")]
        public string? MaritalStatus { get; set; }

        [JsonPropertyName("marriedDate")]
        public DateTime? MarriedDate { get; set; }

        [JsonPropertyName("bpjstk")]
        public string? BPJSTK { get; set; }

        [JsonPropertyName("bpjsKes")]
        public string? BPJSKES { get; set; }

        [JsonPropertyName("nickName")]
        public string? NickName { get; set; }

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("mobilePhone")]
        public string? MobilePhone { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("bloodType")]
        public string? BloodType { get; set; }

        [JsonPropertyName("height")]
        public int? Height { get; set; }

        [JsonPropertyName("weight")]
        public int? Weight { get; set; }

        [JsonPropertyName("officePhone")]
        public string? OfficePhone { get; set; }

        [JsonPropertyName("officeEmail")]
        public string? OfficeEmail { get; set; }

        [JsonPropertyName("buildingCode")]
        public string? BuildingCode { get; set; }

        [JsonPropertyName("roomCode")]
        public string? RoomCode { get; set; }

        [JsonPropertyName("computerName")]
        public string? ComputerName { get; set; }

        [JsonPropertyName("staticIpAddress")]
        public string? StaticIPAddress { get; set; }

        [JsonPropertyName("glasses")]
        public bool? Glasses { get; set; }

        [JsonPropertyName("leftEye")]
        public string? LeftEye { get; set; }

        [JsonPropertyName("rightEye")]
        public string? RightEye { get; set; }

        [JsonPropertyName("hat")]
        public string? Hat { get; set; }

        [JsonPropertyName("helmet")]
        public string? Helmet { get; set; }

        [JsonPropertyName("clothes")]
        public string? Clothes { get; set; }

        [JsonPropertyName("jacket")]
        public string? Jacket { get; set; }

        [JsonPropertyName("pants")]
        public string? Pants { get; set; }

        [JsonPropertyName("shoes")]
        public string? Shoes { get; set; }

        [JsonPropertyName("boots")]
        public string? Boots { get; set; }

        [JsonPropertyName("photoPath")]
        public string? PhotoPath { get; set; }

        [JsonPropertyName("rfid")]
        public string? RFID { get; set; }

        [JsonPropertyName("recruiter")]
        public string? Recruiter { get; set; }

        [JsonPropertyName("hireOrigin")]
        public string? HireOrigin { get; set; }

        [JsonPropertyName("bpjstkLocation")]
        public string? BPJSTKLocation { get; set; }

        [JsonPropertyName("bpjskesLocation")]
        public string? BPJSKesLocation { get; set; }

        [JsonPropertyName("capColorId")]
        public byte? CapColorId { get; set; }

        [JsonPropertyName("pickUpId")]
        public byte? PickUpId { get; set; }

        [JsonPropertyName("faskesId")]
        public int? FaskesId { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

