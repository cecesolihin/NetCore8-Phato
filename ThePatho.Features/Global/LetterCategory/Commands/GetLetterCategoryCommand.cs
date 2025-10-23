using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterCategory.DTO;

namespace ThePatho.Features.Global.LetterCategory.Commands
{
    public class GetLetterCategoryCommand : IRequest<ApiResponse<LetterCategoryItemDto>>
    {
        [JsonPropertyName("filter_LetterCategoryName")]
        public string? FilterLetterCategoryName { get; set; }

        [JsonPropertyName("filter_LetterCategoryCode")]
        public string? FilterLetterCategoryCode { get; set; }

        [JsonPropertyName("filter_DocPattern")]
        public string? FilterDocPattern { get; set; }

        [JsonPropertyName("filter_ResetType")]
        public string? ResetType { get; set; }

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
