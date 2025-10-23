using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.MutationType.DTO;

namespace ThePatho.Features.Organization.MutationType.Commands
{
    public class GetMutationTypeCommand : IRequest<ApiResponse<MutationTypeItemDto>>
    {
        [JsonPropertyName("mutationTypeCode")]
        public string? MutationTypeCode { get; set; }

        [JsonPropertyName("mutationTypeName")]
        public string? MutationTypeName { get; set; }

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
