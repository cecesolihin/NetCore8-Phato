using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.PunishmentType.Commands
{
    public class DeletePunishmentTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("punishment_code")]
        public string PunishmentCode { get; set; } = null!;
    }
}
