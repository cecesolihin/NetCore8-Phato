using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class SubmitAdsCategoryCommand : IRequest<string>
    {
        [JsonPropertyName("adsCategoryCode")]
        public string AdsCategoryCode { get; set; }
        [JsonPropertyName("adsCategoryName")]
        public string AdsCategoryName { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }
    }
}
