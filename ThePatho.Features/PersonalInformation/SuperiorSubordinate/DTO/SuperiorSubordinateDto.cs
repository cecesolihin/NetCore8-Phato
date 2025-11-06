namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.DTO
{
    public class SuperiorSubordinateDto
    {
        public int EmployeeSuperiorID { get; set; }
        public int EmployeeID { get; set; }
        public string Employee { get; set; }
        public string? EffectiveDate { get; set; }
        public string? EndDate { get; set; }
        public string? Remarks { get; set; }
        public string? Status { get; set; }

        public int? Superior1ID { get; set; }
        public string? Superior1 { get; set; }
        public int? Superior2ID { get; set; }
        public string? Superior2 { get; set; }
        public int? Superior3ID { get; set; }
        public string? Superior3 { get; set; }
        public int? Superior4ID { get; set; }
        public string? Superior4 { get; set; }
        public int? Superior5ID { get; set; }
        public string? Superior5 { get; set; }
        public int? Superior6ID { get; set; }
        public string? Superior6 { get; set; }
        public int? Superior7ID { get; set; }
        public string? Superior7 { get; set; }
        public int? Superior8ID { get; set; }
        public string? Superior8 { get; set; }
        public int? Superior9ID { get; set; }
        public string? Superior9 { get; set; }
        public int? Superior10ID { get; set; }
        public string? Superior10 { get; set; }

    }

    public class SuperiorSubordinateItemDto
    {
        public int DataOfRecords { get; set; }
        public List<SuperiorSubordinateDto> SuperiorSubordinateList { get; set; } = new();
    }
}

