using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DocumentType.Service;

namespace ThePatho.Features.Global.DocumentType.Commands
{
    public class DeleteDocumentTypeCommandHandler : IRequestHandler<DeleteDocumentTypeCommand, ApiResponse>
    {
        private readonly IDocumentTypeService DocumentTypeService;

        public DeleteDocumentTypeCommandHandler(IDocumentTypeService _DocumentTypeService)
        {
            DocumentTypeService = _DocumentTypeService;
        }

        public async Task<ApiResponse> Handle(DeleteDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            return await DocumentTypeService.DeleteDocumentType(request);
        }
    }
}





