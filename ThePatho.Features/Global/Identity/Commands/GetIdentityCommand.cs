using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Identity.DTO;

namespace ThePatho.Features.Global.Identity.Commands
{
    public class GetIdentityCommand : IRequest<ApiResponse<IdentityItemDto>>
    {
        [JsonPropertyName("filter_IdentityCode")]
        public string? FilterIdentityCode { get; set; }

        [JsonPropertyName("filter_IdentityName")]
        public string? FilterIdentityName { get; set; }

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

