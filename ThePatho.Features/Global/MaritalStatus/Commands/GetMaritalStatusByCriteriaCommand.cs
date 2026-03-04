using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MaritalStatus.DTO;

namespace ThePatho.Features.Global.MaritalStatus.Commands
{
    public class GetMaritalStatusByCriteriaCommand : IRequest<ApiResponse<MaritalStatusItemDto>>
    {
        [JsonPropertyName("maritalStatusName")]
        public string? MaritalStatusName { get; set; }

        [JsonPropertyName("maritalStatusCode")]
        public string? MaritalStatusCode { get; set; }

    }
}
