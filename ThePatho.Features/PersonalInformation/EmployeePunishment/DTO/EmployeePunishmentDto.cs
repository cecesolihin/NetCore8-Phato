namespace ThePatho.Features.PersonalInformation.EmployeePunishment.DTO
{
    public class EmployeePunishmentDto
    {
        public int EmPunishmentId { get; set; }
        public string LetterNo { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeNo { get; set; }
        public string PostionCode { get; set; }
        public string PositionName { get; set; }
        public string LetterDate { get; set; }
        public string PunishmentType { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string EmployeeName { get; set; }
        public string? RecoveryDate { get; set; }
        public string Remarks { get; set; }
        public bool? IsDeleted { get; set; }
        public string InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string Attachment { get; set; }
    }

    public class EmployeePunishmentItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeePunishmentDto> EmployeePunishmentList { get; set; } = new();
    }
}

