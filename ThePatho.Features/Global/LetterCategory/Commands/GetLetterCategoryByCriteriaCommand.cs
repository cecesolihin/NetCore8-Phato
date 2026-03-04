using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterCategory.DTO;

namespace ThePatho.Features.Global.LetterCategory.Commands
{
    public class GetLetterCategoryByCriteriaCommand : IRequest<ApiResponse<LetterCategoryItemDto>>
    {
        [JsonPropertyName("letterCategoryName")]
        public string? LetterCategoryName { get; set; }

        [JsonPropertyName("letterCategoryCode")]
        public string? LetterCategoryCode { get; set; }

        [JsonPropertyName("docPattern")]
        public string? DocPattern { get; set; }

        [JsonPropertyName("resetType")]
        public string? ResetType { get; set; }

    }
}
