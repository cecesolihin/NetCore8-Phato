using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Features.Recruitment.RequirementRecRequest.DTO
{
    public class RequirementRecRequestDto
    {
        public string RequestNo { get; set; }
        public string QuestionCode { get; set; }
        public string Answer { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}
