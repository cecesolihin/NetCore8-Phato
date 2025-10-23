namespace ThePatho.Features.Global.Nationality.DTO
{
    public class NationalityDto
    {
        public int NationalityId { get; set; }
        public string NationalityName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class NationalityItemDto
    {
        public int DataOfRecords { get; set; }
        public List<NationalityDto> NationalityList { get; set; } = new();
    }
}
