namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.DTO
{
    public class SuperiorSubordinateDto
    {
        public int EmployeeSuperiorID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public string? EffectiveDate { get; set; }
        public string? EndDate { get; set; }
        public string? Remarks { get; set; }

        public int? Superior1ID { get; set; }
        public string? Superior1No { get; set; }
        public string? Superior1Name { get; set; }
        public string? SuperiorPosition1 { get; set; }

        public int? Superior2ID { get; set; }
        public string? Superior2No { get; set; }
        public string? Superior2Name { get; set; }
        public string? SuperiorPosition2 { get; set; }

        public string? Superior2 { get; set; }
        public int? Superior3ID { get; set; }
        public string? Superior3No { get; set; }
        public string? Superior3Name { get; set; }
        public string? SuperiorPosition3 { get; set; }
        public int? Superior4ID { get; set; }
        public string? Superior4No { get; set; }
        public string? Superior4Name { get; set; }
        public string? SuperiorPosition4 { get; set; }
        public int? Superior5ID { get; set; }
        public string? Superior5 { get; set; }
        public string? Superior5No { get; set; }
        public string? Superior5Name { get; set; }
        public string? SuperiorPosition5 { get; set; }
        public int? Superior6ID { get; set; }
        public string? Superior6No { get; set; }
        public string? Superior6Name { get; set; }
        public string? SuperiorPosition6 { get; set; }
        public int? Superior7ID { get; set; }
        public string? Superior7No { get; set; }
        public string? Superior7Name { get; set; }
        public string? SuperiorPosition7 { get; set; }
        public int? Superior8ID { get; set; }
        public string? Superior8No { get; set; }
        public string? Superior8Name { get; set; }
        public string? SuperiorPosition8 { get; set; }
        public int? Superior9ID { get; set; }
        public string? Superior9No { get; set; }
        public string? Superior9Name { get; set; }
        public string? SuperiorPosition9 { get; set; }
        public int? Superior10ID { get; set; }
        public string? Superior10No { get; set; }
        public string? Superior10Name { get; set; }
        public string? SuperiorPosition10 { get; set; }

    }

    public class SuperiorSubordinateItemDto
    {
        public int DataOfRecords { get; set; }
        public List<SuperiorSubordinateDto> SuperiorSubordinateList { get; set; } = new();
    }
}

