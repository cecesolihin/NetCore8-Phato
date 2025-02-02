using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class SubmitAdsCategoryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("adsCategoryCode")]
        public string AdsCategoryCode { get; set; }
        [JsonPropertyName("adsCategoryName")]
        public string AdsCategoryName { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }
    }
}
