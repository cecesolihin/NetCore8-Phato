using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Position.DTO;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class GetPositionCommand :IRequest<ApiResponse<PositionItemDto>>
    {
        [JsonPropertyName("filter_PositionName")]
        public string? FilterPositionName { get; set; }

        [JsonPropertyName("filter_PositionCode")]
        public string? FilterPositionCode { get; set; }

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
