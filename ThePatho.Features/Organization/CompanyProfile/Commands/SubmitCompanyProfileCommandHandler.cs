using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyProfile.Service;

namespace ThePatho.Features.Organization.CompanyProfile.Commands
{
    public class SubmitCompanyProfileCommandHandler : IRequestHandler<SubmitCompanyProfileCommand, ApiResponse>
    {
        private readonly ICompanyProfileService Service;

        public SubmitCompanyProfileCommandHandler(ICompanyProfileService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(SubmitCompanyProfileCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitCompanyProfile(request);
        }
    }
}
