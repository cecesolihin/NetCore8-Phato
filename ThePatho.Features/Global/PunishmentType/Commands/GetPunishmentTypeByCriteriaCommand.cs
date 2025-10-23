using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.PunishmentType.DTO;

namespace ThePatho.Features.Global.PunishmentType.Commands
{
    public class GetPunishmentTypeByCriteriaCommand : IRequest<ApiResponse<PunishmentTypeItemDto>>
    {
        [JsonPropertyName("filter_PunishmentName")]
        public string? FilterPunishmentName { get; set; }

        [JsonPropertyName("filter_PunishmentCode")]
        public string? FilterPunishmentCode { get; set; }
    }
}
