using MediatR;
using ThePatho.Features.Applicant.ApplicantDocument.Service;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands
{
    public class SubmitApplicantDocumentCommandHandler : IRequestHandler<SubmitApplicantDocumentCommand, string>
    {
        private readonly IApplicantDocumentService applicantDocumentService;

        public SubmitApplicantDocumentCommandHandler(IApplicantDocumentService _applicantDocumentService)
        {
            applicantDocumentService = _applicantDocumentService;
        }

        public async Task<string> Handle(SubmitApplicantDocumentCommand request, CancellationToken cancellationToken)
        {
            await applicantDocumentService.SubmitApplicantDocument(request);
            if (request.Action == "ADD")
            {
                return "Applicant Document successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Applicant Document successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
