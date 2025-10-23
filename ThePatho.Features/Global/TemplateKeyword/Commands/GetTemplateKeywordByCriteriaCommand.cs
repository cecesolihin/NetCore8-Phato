using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TemplateKeyword.DTO;

namespace ThePatho.Features.Global.TemplateKeyword.Commands
{
    public class GetTemplateKeywordByCriteriaCommand : IRequest<ApiResponse<TemplateKeywordItemDto>>
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

    }
}
