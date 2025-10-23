using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Religion.DTO;

namespace ThePatho.Features.Global.Religion.Commands
{
    public class GetReligionByCriteriaCommand : IRequest<ApiResponse<ReligionItemDto>>
    {
        [JsonPropertyName("filter_ReligionName")]
        public string? FilterReligionName { get; set; }

        [JsonPropertyName("filter_ReligionId")]
        public int? FilterReligionId { get; set; }

    }
}
