namespace ThePatho.Features.Global.PunishmentType.DTO
{
    public class PunishmentTypeDto
    {
        public string PunishmentCode { get; set; } = null!;
        public string PunishmentName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class PunishmentTypeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<PunishmentTypeDto> PunishmentTypeList { get; set; } = new();
    }
}
