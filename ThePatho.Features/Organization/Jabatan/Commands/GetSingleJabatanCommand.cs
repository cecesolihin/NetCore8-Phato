using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Jabatan.DTO;

namespace ThePatho.Features.Organization.Jabatan.Commands
{
    public class GetSingleJabatanCommand : IRequest<ApiResponse<JabatanDto>>
    {
        [JsonPropertyName("jabatanId")]
        public int JabatanId { get; set; }
    }
}
