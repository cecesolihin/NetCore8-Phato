using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterCategory.DTO;

namespace ThePatho.Features.Global.LetterCategory.Commands
{
    public class GetLetterCategoryByCriteriaCommand : IRequest<ApiResponse<LetterCategoryItemDto>>
    {
        [JsonPropertyName("filter_LetterCategoryName")]
        public string? FilterLetterCategoryName { get; set; }

        [JsonPropertyName("filter_LetterCategoryCode")]
        public string? FilterLetterCategoryCode { get; set; }

        [JsonPropertyName("filter_DocPattern")]
        public string? FilterDocPattern { get; set; }

        [JsonPropertyName("filter_ResetType")]
        public string? ResetType { get; set; }

    }
}
