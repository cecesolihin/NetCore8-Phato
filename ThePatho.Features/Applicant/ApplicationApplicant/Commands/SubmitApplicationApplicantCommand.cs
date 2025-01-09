using MediatR;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class SubmitApplicationApplicantCommand : IRequest<string>
    {
        public int RecApplicationId { get; set; }
        public string ApplicantNo { get; set; }
        public string RequestNo { get; set; }
        public DateTime? AppliedDate { get; set; }
        public string AdsCode { get; set; }
        public string RecruitmentFee { get; set; }
        public string Remarks { get; set; }
        public int? MovedFrom { get; set; }
        public DateTime? DateMoved { get; set; }
        public string Status { get; set; }
        public int? EmployeeId { get; set; }
        public bool? InternalApplicant { get; set; }
        public bool? EmailConfirm { get; set; }
        public string Action { get; set; }

    }

}
