using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantPersonalData.Service;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class DeleteApplicantPersonalDataCommandHandler : IRequestHandler<DeleteApplicantPersonalDataCommand, bool>
    {
        private readonly IApplicantPersonalDataService ApplicantPersonalDataService;

        public DeleteApplicantPersonalDataCommandHandler(IApplicantPersonalDataService _ApplicantPersonalDataService)
        {
            ApplicantPersonalDataService = _ApplicantPersonalDataService;
        }

        public async Task<bool> Handle(DeleteApplicantPersonalDataCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await ApplicantPersonalDataService.DeleteApplicantPersonalData(request);
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
