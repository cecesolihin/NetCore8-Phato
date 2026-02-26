using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class DeletePositionCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("positionCode")]
        public string PositionCode { get; set; }
    }
}
