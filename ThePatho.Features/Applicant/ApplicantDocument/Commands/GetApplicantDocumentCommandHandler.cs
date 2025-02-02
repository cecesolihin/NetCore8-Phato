using MediatR;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;
using ThePatho.Features.Applicant.ApplicantDocument.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands
{
    public class GetApplicantDocumentCommandHandler : IRequestHandler<GetApplicantDocumentCommand, NewApiResponse<ApplicantDocumentItemDto>>
    {
        private readonly IApplicantDocumentService applicantDocumentService;
        public GetApplicantDocumentCommandHandler(IApplicantDocumentService _applicantDocumentService)
        {
            applicantDocumentService =_applicantDocumentService; 
        }
        public async Task<NewApiResponse<ApplicantDocumentItemDto>> Handle(GetApplicantDocumentCommand request, CancellationToken cancellationToken)
        {
            return await applicantDocumentService.GetApplicantDocument(request);

        }
    }
}
