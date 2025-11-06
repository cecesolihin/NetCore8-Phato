using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.ResignType.DTO;

namespace ThePatho.Features.Organization.ResignType.Commands
{
    public class GetResignTypeCommand : IRequest<ApiResponse<ResignTypeItemDto>>
    {
        [JsonPropertyName("resign_type_code")]
        public string ResignTypeCode { get; set; } = null!;

        [JsonPropertyName("resign_type_name")]
        public string ResignTypeName { get; set; } = null!;

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(0)]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}
