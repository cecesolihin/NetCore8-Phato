using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Religion.DTO;

namespace ThePatho.Features.Global.Religion.Commands
{
    public class GetReligionCommand : IRequest<ApiResponse<ReligionItemDto>>
    {
        [JsonPropertyName("filter_ReligionName")]
        public string? FilterReligionName { get; set; }

        [JsonPropertyName("filter_ReligionId")]
        public int? FilterReligionId { get; set; }

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
