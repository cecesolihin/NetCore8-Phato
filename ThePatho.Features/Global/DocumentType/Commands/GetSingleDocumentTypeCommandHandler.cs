using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DocumentType.Service;
using ThePatho.Features.Global.DocumentType.DTO;

namespace ThePatho.Features.Global.DocumentType.Commands
{
    public class GetSingleDocumentTypeCommandHandler : IRequestHandler<GetSingleDocumentTypeCommand, ApiResponse<DocumentTypeDto>>
    {
        private readonly IDocumentTypeService Service;

        public GetSingleDocumentTypeCommandHandler(IDocumentTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<DocumentTypeDto>> Handle(GetSingleDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleDocumentType(request);
        }
    }
}
