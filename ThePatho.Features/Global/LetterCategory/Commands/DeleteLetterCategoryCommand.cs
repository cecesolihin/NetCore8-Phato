using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.LetterCategory.Commands
{
    public class DeleteLetterCategoryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("letter_category_code")]
        public string LetterCategoryCode { get; set; }
    }
}
