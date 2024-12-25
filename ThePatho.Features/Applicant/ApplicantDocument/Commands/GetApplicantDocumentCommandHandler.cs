using MediatR;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;
using ThePatho.Features.Applicant.ApplicantDocument.Service;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands
{
    public class GetApplicantDocumentCommandHandler : IRequestHandler<GetApplicantDocumentCommand, ApplicantDocumentItemDto>
    {
        private readonly IApplicantDocumentService applicantDocumentService;
        public GetApplicantDocumentCommandHandler(IApplicantDocumentService _applicantDocumentService)
        {
            applicantDocumentService =_applicantDocumentService; 
        }
        public async Task<ApplicantDocumentItemDto> Handle(GetApplicantDocumentCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantDocumentService.GetApplicantDocument(request);

            return new ApplicantDocumentItemDto
            {
                DataOfRecords = data.Count,
                ApplicantDocumentList = data,
            };
        }
    }
}
