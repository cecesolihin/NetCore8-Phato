namespace ThePatho.Features.Organization.Jabatan.DTO
{
    public class JabatanDto
    {
        public int JabatanId { get; set; }
        public string JabatanCode { get; set; } = null!;
        public string JabatanName { get; set; } = null!;
        public string? JabatanDescription { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class JabatanItemDto
    {
        public int DataOfRecords { get; set; }
        public List<JabatanDto> JabatanList { get; set; } = new();
    }
}
