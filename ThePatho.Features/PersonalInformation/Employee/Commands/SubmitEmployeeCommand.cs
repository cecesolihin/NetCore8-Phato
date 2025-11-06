using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.Employee.Commands
{
    public class SubmitEmployeeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_id")]
        public int? EmployeeId { get; set; }

        [JsonPropertyName("employee_no")]
        public string? EmployeeNo { get; set; }

        [JsonPropertyName("company_code")]
        public string CompanyCode { get; set; } = null!;

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; } = null!;

        [JsonPropertyName("middlename")]
        public string? MiddleName { get; set; }

        [JsonPropertyName("lastname")]
        public string? LastName { get; set; }

        [JsonPropertyName("fullname")]
        public string Fullname { get; set; } = null!;

        [JsonPropertyName("gender")]
        public string Gender { get; set; } = null!;

        [JsonPropertyName("birth_place")]
        public string? BirthPlace { get; set; }

        [JsonPropertyName("birth_date")]
        public DateTime? BirthDate { get; set; }

        [JsonPropertyName("join_date")]
        public DateTime? JoinDate { get; set; }

        [JsonPropertyName("terminate_date")]
        public DateTime? TerminateDate { get; set; }

        [JsonPropertyName("permanent_date")]
        public DateTime? PermanentDate { get; set; }

        [JsonPropertyName("pension_date")]
        public DateTime? PensionDate { get; set; }

        [JsonPropertyName("contract_end_date")]
        public DateTime? ContractEndDate { get; set; }

        [JsonPropertyName("position_code")]
        public string PositionCode { get; set; } = null!;

        [JsonPropertyName("job_class_code")]
        public string JobClassCode { get; set; } = null!;

        [JsonPropertyName("employment_type_code")]
        public string EmploymentTypeCode { get; set; } = null!;

        [JsonPropertyName("cost_center_code")]
        public string CostCenterCode { get; set; } = null!;

        [JsonPropertyName("work_location_code")]
        public string? WorkLocationCode { get; set; }

        [JsonPropertyName("jabatan_id")]
        public int? JabatanId { get; set; }

        [JsonPropertyName("is_eligible_rehire")]
        public bool? IsEligibleRehire { get; set; }

        [JsonPropertyName("tax_type")]
        public string TaxType { get; set; } = null!;

        [JsonPropertyName("tax_status_code")]
        public string TaxStatusCode { get; set; } = null!;

        [JsonPropertyName("npwp")]
        public string? Npwp { get; set; }

        [JsonPropertyName("tax_location_id")]
        public int? TaxLocationId { get; set; }

        [JsonPropertyName("need_replacement")]
        public bool? NeedReplacement { get; set; }

        [JsonPropertyName("pay_group")]
        public string? PayGroup { get; set; }

        [JsonPropertyName("nationality_id")]
        public int? NationalityId { get; set; }

        [JsonPropertyName("religion_id")]
        public int? ReligionId { get; set; }

        [JsonPropertyName("marital_status")]
        public string? MaritalStatus { get; set; }

        [JsonPropertyName("married_date")]
        public DateTime? MarriedDate { get; set; }

        [JsonPropertyName("bpjstk")]
        public string? BPJSTK { get; set; }

        [JsonPropertyName("bpjs_kes")]
        public string? BPJSKES { get; set; }

        [JsonPropertyName("nickname")]
        public string? NickName { get; set; }

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("mobile_phone")]
        public string? MobilePhone { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("blood_type")]
        public string? BloodType { get; set; }

        [JsonPropertyName("height")]
        public int? Height { get; set; }

        [JsonPropertyName("weight")]
        public int? Weight { get; set; }

        [JsonPropertyName("office_phone")]
        public string? OfficePhone { get; set; }

        [JsonPropertyName("office_email")]
        public string? OfficeEmail { get; set; }

        [JsonPropertyName("building_code")]
        public string? BuildingCode { get; set; }

        [JsonPropertyName("room_code")]
        public string? RoomCode { get; set; }

        [JsonPropertyName("computer_name")]
        public string? ComputerName { get; set; }

        [JsonPropertyName("static_ip_address")]
        public string? StaticIPAddress { get; set; }

        [JsonPropertyName("glasses")]
        public bool? Glasses { get; set; }

        [JsonPropertyName("left_eye")]
        public string? LeftEye { get; set; }

        [JsonPropertyName("right_eye")]
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

        [JsonPropertyName("photo_path")]
        public string? PhotoPath { get; set; }

        [JsonPropertyName("rfid")]
        public string? RFID { get; set; }

        [JsonPropertyName("recruiter")]
        public string? Recruiter { get; set; }

        [JsonPropertyName("hire_origin")]
        public string? HireOrigin { get; set; }

        [JsonPropertyName("bpjstk_location")]
        public string? BPJSTKLocation { get; set; }

        [JsonPropertyName("bpjskes_location")]
        public string? BPJSKesLocation { get; set; }

        [JsonPropertyName("cap_color_id")]
        public byte? CapColorId { get; set; }

        [JsonPropertyName("pickup_id")]
        public byte? PickUpId { get; set; }

        [JsonPropertyName("faskes_id")]
        public int? FaskesId { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

