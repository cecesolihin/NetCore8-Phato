using MediatR;
using ThePatho.Features.Applicant.ApplicantDocument.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands
{
    public class SubmitApplicantDocumentCommandHandler : IRequestHandler<SubmitApplicantDocumentCommand, ApiResponse>
    {
        private readonly IApplicantDocumentService applicantDocumentService;

        public SubmitApplicantDocumentCommandHandler(IApplicantDocumentService _applicantDocumentService)
        {
            applicantDocumentService = _applicantDocumentService;
        }

        public async Task<ApiResponse> Handle(SubmitApplicantDocumentCommand request, CancellationToken cancellationToken)
        {
            return await applicantDocumentService.SubmitApplicantDocument(request);
            
        }
    }
}
