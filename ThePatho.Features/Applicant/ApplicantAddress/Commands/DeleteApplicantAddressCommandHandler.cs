using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantAddress.Service;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class DeleteApplicantAddressCommandHandler : IRequestHandler<DeleteApplicantAddressCommand, bool>
    {
        private readonly IApplicantAddressService applicantAddressService;

        public DeleteApplicantAddressCommandHandler(IApplicantAddressService _applicantAddressService)
        {
            applicantAddressService = _applicantAddressService;
        }

        public async Task<bool> Handle(DeleteApplicantAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await applicantAddressService.DeleteApplicantAddress(request);
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
