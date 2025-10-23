using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Position.DTO;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class GetSinglePositionCommand : IRequest<ApiResponse<PositionDto>>
    {
        [JsonPropertyName("filter_PositionCode")]
        public string FilterPositionCode { get; set; }
    }
}
