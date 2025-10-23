using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.PunishmentType.Commands
{
    public class SubmitPunishmentTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("punishment_code")]
        public string PunishmentCode { get; set; } = null!;

        [JsonPropertyName("punishment_name")]
        public string PunishmentName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
