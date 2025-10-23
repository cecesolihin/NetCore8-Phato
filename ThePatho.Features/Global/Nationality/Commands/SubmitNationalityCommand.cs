using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Nationality.Commands
{
    public class SubmitNationalityCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("nationality_id")]
        public int? NationalityId { get; set; }

        [JsonPropertyName("nationality_name")]
        public string NationalityName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
