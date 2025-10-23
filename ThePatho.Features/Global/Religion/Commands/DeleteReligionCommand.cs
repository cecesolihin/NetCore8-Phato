using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Religion.Commands
{
    public class DeleteReligionCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("religion_id")]
        public int ReligionId { get; set; }
    }
}
