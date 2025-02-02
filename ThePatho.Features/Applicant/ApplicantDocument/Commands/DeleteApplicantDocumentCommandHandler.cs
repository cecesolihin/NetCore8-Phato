using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantDocument.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands
{
    public class DeleteApplicantDocumentCommandHandler : IRequestHandler<DeleteApplicantDocumentCommand, ApiResponse>
    {
        private readonly IApplicantDocumentService applicantDocumentService;

        public DeleteApplicantDocumentCommandHandler(IApplicantDocumentService _applicantDocumentService)
        {
            applicantDocumentService = _applicantDocumentService;
        }

        public async Task<ApiResponse> Handle(DeleteApplicantDocumentCommand request, CancellationToken cancellationToken)
        {
            return await applicantDocumentService.DeleteApplicantDocument(request);
              
        }
    }
}
