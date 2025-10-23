using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.PunishmentType.DTO;

namespace ThePatho.Features.Global.PunishmentType.Commands
{
    public class GetPunishmentTypeCommand : IRequest<ApiResponse<PunishmentTypeItemDto>>
    {
        [JsonPropertyName("filter_PunishmentName")]
        public string? FilterPunishmentName { get; set; }

        [JsonPropertyName("filter_PunishmentCode")]
        public string? FilterPunishmentCode { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}
