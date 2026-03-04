using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Religion.DTO;

namespace ThePatho.Features.Global.Religion.Commands
{
    public class GetReligionByCriteriaCommand : IRequest<ApiResponse<ReligionItemDto>>
    {
        [JsonPropertyName("religionName")]
        public string? ReligionName { get; set; }

        [JsonPropertyName("religionId")]
        public int? ReligionId { get; set; }

    }
}
