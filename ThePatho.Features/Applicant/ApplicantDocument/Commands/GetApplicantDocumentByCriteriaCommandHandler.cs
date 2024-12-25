using MediatR;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;
using ThePatho.Features.Applicant.ApplicantDocument.Service;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands 
{
    public class GetApplicantDocumentByCriteriaCommandHandler : IRequestHandler<GetApplicantDocumentByCriteriaCommand, ApplicantDocumentDto>
    {
        private readonly IApplicantDocumentService applicantDocumentService;
        public GetApplicantDocumentByCriteriaCommandHandler(IApplicantDocumentService _applicantDocumentService)
        {
            applicantDocumentService = _applicantDocumentService;
        }
        public async Task<ApplicantDocumentDto> Handle(GetApplicantDocumentByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantDocumentService.GetApplicantDocumentByCriteria(request);

            return data;
        }
    }
}
