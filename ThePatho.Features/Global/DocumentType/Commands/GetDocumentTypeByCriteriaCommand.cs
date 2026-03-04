using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DocumentType.DTO;

namespace ThePatho.Features.Global.DocumentType.Commands
{
    public class GetDocumentTypeByCriteriaCommand : IRequest<ApiResponse<DocumentTypeItemDto>>
    {
        [JsonPropertyName("documentTypeName")]
        public string? DocumentTypeName { get; set; }

        [JsonPropertyName("documentTypeCode")]
        public string? DocumentTypeCode { get; set; }

    }
}





