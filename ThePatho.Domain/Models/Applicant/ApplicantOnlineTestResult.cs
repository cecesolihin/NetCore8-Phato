using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Applicant
{
    public class ApplicantOnlineTestResult
    {
        public int AppResultId { get; set; }
        public string OnlineTestCode { get; set; }
        public string ApplicantNo { get; set; }
        public string QuestionnaireCode { get; set; }
        public string QuestionnaireName { get; set; }
        public string AnswerMethod { get; set; }
        public string Remarks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SubmitDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<ApplicantOnlineTestAnswer> AppAnswers { get; set; }
    }

}
