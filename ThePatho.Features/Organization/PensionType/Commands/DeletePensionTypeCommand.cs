using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.PensionType.Commands
{
    public class DeletePensionTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("pensionTypeCode")]
        public string PensionTypeCode { get; set; } = null!;
    }
}
