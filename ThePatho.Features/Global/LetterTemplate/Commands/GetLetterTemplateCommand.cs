using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterTemplate.DTO;

namespace ThePatho.Features.Global.LetterTemplate.Commands
{
    public class GetLetterTemplateCommand : IRequest<ApiResponse<LetterTemplateItemDto>>
    {
        [JsonPropertyName("filter_LetterTemplateName")]
        public string? FilterLetterTemplateName { get; set; }

        [JsonPropertyName("filter_LetterTemplateCode")]
        public string? FilterLetterTemplateCode { get; set; }

        [JsonPropertyName("filter_Content")]
        public string? Content { get; set; }
        [JsonPropertyName("filter_LetterTemplateType")]
        public string? LetterTemplateType { get; set; }
        [JsonPropertyName("Filter_LetterCategoryCode")]
        public string? FilterLetterCategoryCode { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}
