using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TemplateKeyword.DTO;

namespace ThePatho.Features.Global.TemplateKeyword.Commands
{
    public class GetSingleTemplateKeywordCommand : IRequest<ApiResponse<TemplateKeywordDto>>
    {
        [JsonPropertyName("filter_KeywordCode")]
        public string FilterKeywordCode { get; set; } = null!;
    }
}
