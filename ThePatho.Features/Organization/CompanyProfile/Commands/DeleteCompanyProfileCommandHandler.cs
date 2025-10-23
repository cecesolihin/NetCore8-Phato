using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyProfile.Service;

namespace ThePatho.Features.Organization.CompanyProfile.Commands
{
    public class DeleteCompanyProfileCommandHandler : IRequestHandler<DeleteCompanyProfileCommand, ApiResponse>
    {
        private readonly ICompanyProfileService Service;

        public DeleteCompanyProfileCommandHandler(ICompanyProfileService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(DeleteCompanyProfileCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteCompanyProfile(request);
        }
    }
}
