using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.TemplateKeyword.Commands
{
    public class DeleteTemplateKeywordCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("keyword_code")]
        public string KeywordCode { get; set; } = null!;
    }
}
