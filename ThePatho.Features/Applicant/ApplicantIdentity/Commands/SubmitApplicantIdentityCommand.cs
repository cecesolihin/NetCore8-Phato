using MediatR;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class SubmitApplicantIdentityCommand : IRequest<string>
    {
        public string ApplicantNo { get; set; }
        public string IdentityCode { get; set; }
        public string IdentityNo { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string FileFullPath { get; set; }
        public string FileName { get; set; }
        public string Remark { get; set; }
        public string Action { get; set; }

    }

}
