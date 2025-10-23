using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterCategory.DTO;

namespace ThePatho.Features.Global.LetterCategory.Commands
{
    public class GetSingleLetterCategoryCommand : IRequest<ApiResponse<LetterCategoryDto>>
    {
        [JsonPropertyName("filter_LetterCategoryCode")]
        public string FilterLetterCategoryCode { get; set; }
    }
}
