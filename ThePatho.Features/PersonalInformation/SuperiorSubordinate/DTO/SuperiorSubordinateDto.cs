namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.DTO
{
    public class SuperiorSubordinateDto
    {
        public int EmployeeSuperiorID { get; set; }
        public int EmployeeID { get; set; }
        public string? EffectiveDate { get; set; }
        public string? EndDate { get; set; }
        public string? Remarks { get; set; }
        public string? Status { get; set; }

        public int? Superior1ID { get; set; }
        public int? Superior2ID { get; set; }
        public int? Superior3ID { get; set; }
        public int? Superior4ID { get; set; }
        public int? Superior5ID { get; set; }
        public int? Superior6ID { get; set; }
        public int? Superior7ID { get; set; }
        public int? Superior8ID { get; set; }
        public int? Superior9ID { get; set; }
        public int? Superior10ID { get; set; }
        public int? Superior11ID { get; set; }
        public int? Superior12ID { get; set; }
        public int? Superior13ID { get; set; }
        public int? Superior14ID { get; set; }
        public int? Superior15ID { get; set; }
        public int? Superior16ID { get; set; }
        public int? Superior17ID { get; set; }
        public int? Superior18ID { get; set; }
        public int? Superior19ID { get; set; }
        public int? Superior20ID { get; set; }
        public int? Superior21ID { get; set; }
        public int? Superior22ID { get; set; }
        public int? Superior23ID { get; set; }
        public int? Superior24ID { get; set; }
        public int? Superior25ID { get; set; }
        public int? Superior26ID { get; set; }
        public int? Superior27ID { get; set; }
        public int? Superior28ID { get; set; }
        public int? Superior29ID { get; set; }
        public int? Superior30ID { get; set; }

        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class SuperiorSubordinateItemDto
    {
        public int DataOfRecords { get; set; }
        public List<SuperiorSubordinateDto> SuperiorSubordinateList { get; set; } = new();
    }
}

