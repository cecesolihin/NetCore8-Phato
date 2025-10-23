using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.ResignType.Commands
{
    public class DeleteResignTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("resign_type_code")]
        public string ResignTypeCode { get; set; } = null!;
    }
}
