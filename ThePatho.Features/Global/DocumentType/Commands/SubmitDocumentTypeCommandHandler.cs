using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DocumentType.Service;

namespace ThePatho.Features.Global.DocumentType.Commands
{
    public class SubmitDocumentTypeCommandHandler : IRequestHandler<SubmitDocumentTypeCommand, ApiResponse>
    {
        private readonly IDocumentTypeService DocumentTypeService;

        public SubmitDocumentTypeCommandHandler(IDocumentTypeService _DocumentTypeService)
        {
            DocumentTypeService = _DocumentTypeService;
        }

        public async Task<ApiResponse> Handle(SubmitDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            return await DocumentTypeService.SubmitDocumentType(request);
        }
    }
}





