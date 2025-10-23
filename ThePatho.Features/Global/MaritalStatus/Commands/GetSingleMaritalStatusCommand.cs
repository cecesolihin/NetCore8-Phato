using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MaritalStatus.DTO;

namespace ThePatho.Features.Global.MaritalStatus.Commands
{
    public class GetSingleMaritalStatusCommand : IRequest<ApiResponse<MaritalStatusDto>>
    {
        [JsonPropertyName("filter_MaritalStatusCode")]
        public string FilterMaritalStatusCode { get; set; } = null!;
    }
}
