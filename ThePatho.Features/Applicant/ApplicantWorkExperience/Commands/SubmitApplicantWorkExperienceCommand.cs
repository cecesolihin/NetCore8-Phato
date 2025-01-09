using MediatR;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class SubmitApplicantWorkExperienceCommand : IRequest<string>
    {
        public int AppWorkExpId { get; set; }
        public string ApplicantNo { get; set; }
        public DateTime StartWorking { get; set; }
        public DateTime? EndWorking { get; set; }
        public string Company { get; set; }
        public string BusinessField { get; set; }
        public string Address { get; set; }
        public string CityCode { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string ResignReasonCode { get; set; }
        public string EmpTypeCode { get; set; }
        public string Organization { get; set; }
        public string JobLevel { get; set; }
        public string JobDesc { get; set; }
        public string ReferenceName { get; set; }
        public string ReferencePhone { get; set; }
        public string ReferenceEmail { get; set; }
        public string Remark { get; set; }
        public bool IsLastWorkExperience { get; set; }
        public string Action { get; set; }

    }

}
