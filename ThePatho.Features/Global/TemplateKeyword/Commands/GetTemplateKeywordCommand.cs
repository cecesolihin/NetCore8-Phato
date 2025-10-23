using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TemplateKeyword.DTO;

namespace ThePatho.Features.Global.TemplateKeyword.Commands
{
    public class GetTemplateKeywordCommand : IRequest<ApiResponse<TemplateKeywordItemDto>>
    {
        [JsonPropertyName("filter_KeywordName")]
        public string? FilterKeywordName { get; set; }

        [JsonPropertyName("filter_KeywordCode")]
        public string? FilterKeywordCode { get; set; }

        [JsonPropertyName("filter_TableName")]
        public string? FilterTableName { get; set; }

        [JsonPropertyName("filter_TableName")]
        public string? FilterValue { get; set; }

        [JsonPropertyName("filter_ColumnName")]
        public string? FilterColumnName { get; set; }

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
