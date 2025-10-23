using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterTemplate.DTO;

namespace ThePatho.Features.Global.LetterTemplate.Commands
{
    public class GetLetterTemplateByCriteriaCommand : IRequest<ApiResponse<LetterTemplateItemDto>>
    {
        [JsonPropertyName("filter_LetterTemplateName")]
        public string? FilterLetterTemplateName { get; set; }

        [JsonPropertyName("filter_LetterTemplateCode")]
        public string? FilterLetterTemplateCode { get; set; }

        [JsonPropertyName("Filter_LetterCategoryCode")]
        public string? FilterLetterCategoryCode { get; set; }
        [JsonPropertyName("filter_Content")]
        public string? Content { get; set; }
        [JsonPropertyName("filter_LetterTemplateType")]
        public string? LetterTemplateType { get; set; }

    }
}
