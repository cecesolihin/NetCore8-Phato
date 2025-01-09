using MediatR;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands
{
    public class SubmitApplicantDocumentCommand : IRequest<string>
    {
        public string ApplicantNo { get; set; }
        public string DocumentTypeCode { get; set; }
        public string FilePath { get; set; }
        public string Remark { get; set; }
        public string Action { get; set; }

    }

}
