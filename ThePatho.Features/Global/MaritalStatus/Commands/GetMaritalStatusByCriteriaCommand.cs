using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MaritalStatus.DTO;

namespace ThePatho.Features.Global.MaritalStatus.Commands
{
    public class GetMaritalStatusByCriteriaCommand : IRequest<ApiResponse<MaritalStatusItemDto>>
    {
        [JsonPropertyName("filter_MaritalStatusName")]
        public string? FilterMaritalStatusName { get; set; }

        [JsonPropertyName("filter_MaritalStatusCode")]
        public string? FilterMaritalStatusCode { get; set; }

    }
}
