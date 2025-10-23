using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.LetterCategory.Commands
{
    public class SubmitLetterCategoryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("letter_category_code")]
        public string LetterCategoryCode { get; set; } = null!;

        [JsonPropertyName("letter_category_name")]
        public string? LetterCategoryName { get; set; }

        [JsonPropertyName("doc_pattern")]
        public string? DocPattern { get; set; }

        [JsonPropertyName("reset_type")]
        public string? ResetType { get; set; }

        [JsonPropertyName("mapping_letter_template")]
        public string? MappingLetterTemplate { get; set; }

        [JsonPropertyName("sequence_no")]
        public int SequenceNo { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
