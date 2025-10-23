namespace ThePatho.Features.PersonalInformation.EmployeePunishment.DTO
{
    public class EmployeePunishmentDto
    {
        public int EmPunishmentId { get; set; }
        public string LetterNo { get; set; } = null!;
        public int EmployeeId { get; set; }
        public string LetterDate { get; set; } = null!;
        public string PunishmentType { get; set; } = null!;
        public string ValidFrom { get; set; } = null!;
        public string ValidTo { get; set; } = null!;
        public string? RecoveryDate { get; set; }
        public string Remarks { get; set; } = null!;
        public bool? IsDeleted { get; set; }
        public string InsertedBy { get; set; } = null!;
        public string? InsertedDate { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public string? ModifiedDate { get; set; }
        public string Attachment { get; set; } = null!;
    }

    public class EmployeePunishmentItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeePunishmentDto> EmployeePunishmentList { get; set; } = new();
    }
}

