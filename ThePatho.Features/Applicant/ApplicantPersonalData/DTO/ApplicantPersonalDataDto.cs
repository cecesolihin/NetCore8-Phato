
namespace ThePatho.Features.Applicant.ApplicantPersonalData.DTO
{
    public class ApplicantPersonalDataDto
    {
        public string ApplicantNo { get; set; }
        public int? NationalityId { get; set; }
        public int? ReligionId { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime? MarriedDate { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string BloodType { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public byte[] Photo { get; set; }
        public string Reference { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContact { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class ApplicantPersonalDataItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ApplicantPersonalDataDto> ApplicantPersonalDataList { get; set; } = new();
    }
}
