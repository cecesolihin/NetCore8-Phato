using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ResignReason.DTO;

namespace ThePatho.Features.Global.ResignReason.Commands
{
    public class GetResignReasonCommand : IRequest<ApiResponse<ResignReasonItemDto>>
    {
        [JsonPropertyName("filter_ResignReasonName")]
        public string? FilterResignReasonName { get; set; }

        [JsonPropertyName("filter_ResignReasonCode")]
        public string? FilterResignReasonCode { get; set; }

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
