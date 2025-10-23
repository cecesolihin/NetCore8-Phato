using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Jabatan.DTO;

namespace ThePatho.Features.Organization.Jabatan.Commands
{
    public class GetJabatanByCriteriaCommand : IRequest<ApiResponse<JabatanItemDto>>
    {
        [JsonPropertyName("jabatanCode")]
        public string? JabatanCode { get; set; }

        [JsonPropertyName("jabatanName")]
        public string? JabatanName { get; set; }

        [JsonPropertyName("jabatanDescription")]
        public string? JabatanDescription { get; set; }
    }
}
