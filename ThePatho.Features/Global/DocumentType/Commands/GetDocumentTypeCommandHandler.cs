using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DocumentType.Service;
using ThePatho.Features.Global.DocumentType.DTO;

namespace ThePatho.Features.Global.DocumentType.Commands
{
    public class GetDocumentTypeCommandHandler : IRequestHandler<GetDocumentTypeCommand, ApiResponse<DocumentTypeItemDto>>
    {
        private readonly IDocumentTypeService DocumentTypeService;

        public GetDocumentTypeCommandHandler(IDocumentTypeService _DocumentTypeService)
        {
            DocumentTypeService = _DocumentTypeService;
        }

        public async Task<ApiResponse<DocumentTypeItemDto>> Handle(GetDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            return await DocumentTypeService.GetDocumentType(request);
        }
    }
}





