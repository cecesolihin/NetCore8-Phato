using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantDocument.Service;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands
{
    public class DeleteApplicantDocumentCommandHandler : IRequestHandler<DeleteApplicantDocumentCommand, bool>
    {
        private readonly IApplicantDocumentService applicantDocumentService;

        public DeleteApplicantDocumentCommandHandler(IApplicantDocumentService _applicantDocumentService)
        {
            applicantDocumentService = _applicantDocumentService;
        }

        public async Task<bool> Handle(DeleteApplicantDocumentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await applicantDocumentService.DeleteApplicantDocument(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }
}
