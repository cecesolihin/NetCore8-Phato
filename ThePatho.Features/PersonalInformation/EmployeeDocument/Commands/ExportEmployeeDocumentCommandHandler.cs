using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.EmployeeDocument.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeDocument.Commands
{
    public class ExportEmployeeDocumentCommandHandler : IRequestHandler<ExportEmployeeDocumentCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmployeeDocumentService documentService;

        public ExportEmployeeDocumentCommandHandler(IEmployeeDocumentService _documentService)
        {
            documentService = _documentService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmployeeDocumentCommand request, CancellationToken cancellationToken)
        {
            return await documentService.ExportEmployeeDocumentAsync(request.Type);
        }
    }
}
