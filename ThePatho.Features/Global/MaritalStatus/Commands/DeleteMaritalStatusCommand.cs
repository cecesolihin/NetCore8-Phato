using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.MaritalStatus.Commands
{
    public class DeleteMaritalStatusCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("marital_status_code")]
        public string MaritalStatusCode { get; set; } = null!;
    }
}
