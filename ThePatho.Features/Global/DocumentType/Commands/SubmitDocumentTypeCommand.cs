using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.DocumentType.Commands
{
    public class SubmitDocumentTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("documentTypeCode")]
        public string DocumentTypeCode { get; set; } = null!;

        [JsonPropertyName("documentTypeName")]
        public string? DocumentTypeName { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}





