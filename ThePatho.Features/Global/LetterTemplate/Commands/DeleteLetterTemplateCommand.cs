using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.LetterTemplate.Commands
{
    public class DeleteLetterTemplateCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("letter_template_code")]
        public string LetterTemplateCode { get; set; }
    }
}
