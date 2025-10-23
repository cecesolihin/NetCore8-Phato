using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.PensionType.DTO;

namespace ThePatho.Features.Organization.PensionType.Commands
{
    public class GetPensionTypeCommand : IRequest<ApiResponse<PensionTypeItemDto>>
    {
        [JsonPropertyName("pensionTypeCode")]
        public string? PensionTypeCode { get; set; }

        [JsonPropertyName("pensionTypeName")]
        public string? PensionTypeName { get; set; }

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
