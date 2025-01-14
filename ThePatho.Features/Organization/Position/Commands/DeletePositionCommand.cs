using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class DeletePositionCommand : IRequest<bool>
    {
        [JsonPropertyName("position_code")]
        public string PositionCode { get; set; }
    }
}
