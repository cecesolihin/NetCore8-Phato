using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.PunishmentType.DTO;

namespace ThePatho.Features.Global.PunishmentType.Commands
{
    public class GetSinglePunishmentTypeCommand : IRequest<ApiResponse<PunishmentTypeDto>>
    {
        [JsonPropertyName("filter_PunishmentCode")]
        public string FilterPunishmentCode { get; set; }
    }
}
