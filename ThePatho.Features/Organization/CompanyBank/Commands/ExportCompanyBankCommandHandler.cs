using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyBank.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.CompanyBank.Commands
{
    public class ExportCompanyBankCommandHandler : IRequestHandler<ExportCompanyBankCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ICompanyBankService service;

        public ExportCompanyBankCommandHandler(ICompanyBankService service)
        {
            this.service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportCompanyBankCommand request, CancellationToken cancellationToken)
        {
            return await service.ExportCompanyBankAsync(request.Type);
        }
    }
}