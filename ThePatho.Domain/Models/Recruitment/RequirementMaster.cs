
namespace ThePatho.Domain.Models.Recruitment
{
    public class RequirementMaster
    {
        public string QuestionCode { get; set; }
        public string? QuestionName { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; } 
        public DateTime? ModifiedDate { get; set; }
    }
}
