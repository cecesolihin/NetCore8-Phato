using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Religion.DTO;

namespace ThePatho.Features.Global.Religion.Commands
{
    public class GetSingleReligionCommand : IRequest<ApiResponse<ReligionDto>>
    {
        [JsonPropertyName("filter_Name")]
        public string? FilterName { get; set; }

        [JsonPropertyName("filter_ReligionId")]
        public int? FilterReligionId { get; set; }
    }
}
