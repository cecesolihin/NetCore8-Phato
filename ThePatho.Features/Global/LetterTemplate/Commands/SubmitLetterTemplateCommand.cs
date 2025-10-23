using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.LetterTemplate.Commands
{
    public class SubmitLetterTemplateCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("letter_template_code")]
        public string LetterTemplateCode { get; set; } = null!;

        [JsonPropertyName("letter_template_name")]
        public string LetterTemplateName { get; set; } = null!;

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("letter_template_type")]
        public string? LetterTemplateType { get; set; }

        [JsonPropertyName("file_upload")]
        public string? FileUpload { get; set; }

        [JsonPropertyName("letter_category_code")]
        public string? LetterCategoryCode { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
