using MediatR;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands
{
    public class DeleteApplicantDocumentCommand : IRequest<bool>
    {
        public string ApplicantNo { get; set; }
        public string DocumentTypeCode { get; set; }
    }
}
