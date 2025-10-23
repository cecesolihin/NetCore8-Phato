using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Jabatan.Commands
{
    public class SubmitJabatanCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("jabatanId")]
        public int JabatanId { get; set; }

        [JsonPropertyName("jabatanCode")]
        public string JabatanCode { get; set; } = null!;

        [JsonPropertyName("jabatanName")]
        public string JabatanName { get; set; } = null!;

        [JsonPropertyName("jabatanDescription")]
        public string? JabatanDescription { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
