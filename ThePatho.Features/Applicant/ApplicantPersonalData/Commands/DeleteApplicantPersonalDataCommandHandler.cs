using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantPersonalData.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class DeleteApplicantPersonalDataCommandHandler : IRequestHandler<DeleteApplicantPersonalDataCommand, ApiResponse>
    {
        private readonly IApplicantPersonalDataService ApplicantPersonalDataService;

        public DeleteApplicantPersonalDataCommandHandler(IApplicantPersonalDataService _ApplicantPersonalDataService)
        {
            ApplicantPersonalDataService = _ApplicantPersonalDataService;
        }

        public async Task<ApiResponse> Handle(DeleteApplicantPersonalDataCommand request, CancellationToken cancellationToken)
        {
            return await ApplicantPersonalDataService.DeleteApplicantPersonalData(request);
                
        }
    }
}
