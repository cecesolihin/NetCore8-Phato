using MediatR;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;
using ThePatho.Features.Applicant.ApplicantDocument.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands 
{
    public class GetApplicantDocumentByCriteriaCommandHandler : IRequestHandler<GetApplicantDocumentByCriteriaCommand, ApiResponse<ApplicantDocumentDto>>
    {
        private readonly IApplicantDocumentService applicantDocumentService;
        public GetApplicantDocumentByCriteriaCommandHandler(IApplicantDocumentService _applicantDocumentService)
        {
            applicantDocumentService = _applicantDocumentService;
        }
        public async Task<ApiResponse<ApplicantDocumentDto>> Handle(GetApplicantDocumentByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantDocumentService.GetApplicantDocumentByCriteria(request);

        }
    }
}
