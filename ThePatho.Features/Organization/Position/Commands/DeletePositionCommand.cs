using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class DeletePositionCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("position_code")]
        public string PositionCode { get; set; }
    }
}
