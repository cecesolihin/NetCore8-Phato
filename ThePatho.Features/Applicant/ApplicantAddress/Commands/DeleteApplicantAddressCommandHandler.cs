using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantAddress.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class DeleteApplicantAddressCommandHandler : IRequestHandler<DeleteApplicantAddressCommand, ApiResponse>
    {
        private readonly IApplicantAddressService applicantAddressService;

        public DeleteApplicantAddressCommandHandler(IApplicantAddressService _applicantAddressService)
        {
            applicantAddressService = _applicantAddressService;
        }

        public async Task<ApiResponse> Handle(DeleteApplicantAddressCommand request, CancellationToken cancellationToken)
        {
           return await applicantAddressService.DeleteApplicantAddress(request);
                
        }
    }
}
