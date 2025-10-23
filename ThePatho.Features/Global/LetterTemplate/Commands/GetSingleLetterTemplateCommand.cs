using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterTemplate.DTO;

namespace ThePatho.Features.Global.LetterTemplate.Commands
{
    public class GetSingleLetterTemplateCommand : IRequest<ApiResponse<LetterTemplateDto>>
    {
        [JsonPropertyName("filter_LetterTemplateCode")]
        public string? FilterLetterTemplateCode { get; set; }
    }
}
