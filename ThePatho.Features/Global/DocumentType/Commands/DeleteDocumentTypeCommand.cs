using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.DocumentType.Commands
{
    public class DeleteDocumentTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("documentTypeCode")]
        public string? DocumentTypeCode { get; set; }
    }
}


