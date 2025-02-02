using MediatR;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;
using ThePatho.Features.Applicant.ApplicantDocument.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands 
{
    public class GetApplicantDocumentByCriteriaCommandHandler : IRequestHandler<GetApplicantDocumentByCriteriaCommand, NewApiResponse<ApplicantDocumentDto>>
    {
        private readonly IApplicantDocumentService applicantDocumentService;
        public GetApplicantDocumentByCriteriaCommandHandler(IApplicantDocumentService _applicantDocumentService)
        {
            applicantDocumentService = _applicantDocumentService;
        }
        public async Task<NewApiResponse<ApplicantDocumentDto>> Handle(GetApplicantDocumentByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantDocumentService.GetApplicantDocumentByCriteria(request);

        }
    }
}
