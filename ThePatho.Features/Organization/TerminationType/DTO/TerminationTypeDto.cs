namespace ThePatho.Features.Organization.TerminationType.DTO
{
    public class TerminationTypeDto
    {
        public string TerminationTypeCode { get; set; } = null!;
        public string TerminationTypeName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class TerminationTypeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<TerminationTypeDto> TerminationTypeList { get; set; } = new();
    }
}
