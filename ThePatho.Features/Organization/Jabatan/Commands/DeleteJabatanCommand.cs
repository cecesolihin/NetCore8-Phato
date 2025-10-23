using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Jabatan.Commands
{
    public class DeleteJabatanCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("jabatan_id")]
        public int JabatanId { get; set; }
    }
}
