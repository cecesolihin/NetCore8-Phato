using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Jabatan.DTO;

namespace ThePatho.Features.Organization.Jabatan.Commands
{
    public class GetJabatanCommand : IRequest<ApiResponse<JabatanItemDto>>
    {
        [JsonPropertyName("jabatanCode")]
        public string? JabatanCode { get; set; }

        [JsonPropertyName("jabatanName")]
        public string? JabatanName { get; set; }

        [JsonPropertyName("jabatanDescription")]
        public string? JabatanDescription { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}
