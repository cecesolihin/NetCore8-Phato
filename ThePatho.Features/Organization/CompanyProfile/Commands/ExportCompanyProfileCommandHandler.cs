using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyProfile.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.CompanyProfile.Commands
{
    public class ExportCompanyProfileCommandHandler : IRequestHandler<ExportCompanyProfileCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ICompanyProfileService service;

        public ExportCompanyProfileCommandHandler(ICompanyProfileService service)
        {
            this.service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportCompanyProfileCommand request, CancellationToken cancellationToken)
        {
            return await service.ExportCompanyProfileAsync(request.Type);
        }
    }
}