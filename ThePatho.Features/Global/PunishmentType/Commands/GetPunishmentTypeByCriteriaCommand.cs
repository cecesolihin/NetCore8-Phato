using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.PunishmentType.DTO;

namespace ThePatho.Features.Global.PunishmentType.Commands
{
    public class GetPunishmentTypeByCriteriaCommand : IRequest<ApiResponse<PunishmentTypeItemDto>>
    {
        [JsonPropertyName("PunishmentName")]
        public string? PunishmentName { get; set; }

        [JsonPropertyName("PunishmentCode")]
        public string? PunishmentCode { get; set; }
    }
}
