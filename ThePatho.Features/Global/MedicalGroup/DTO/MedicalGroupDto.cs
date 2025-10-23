namespace ThePatho.Features.Global.MedicalGroup.DTO
{
    public class MedicalGroupDto
    {
        public string MedicalGroupCode { get; set; } = null!;
        public string MedicalGroupName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class MedicalGroupItemDto
    {
        public int DataOfRecords { get; set; }
        public List<MedicalGroupDto> MedicalGroupList { get; set; } = new();
    }
}
