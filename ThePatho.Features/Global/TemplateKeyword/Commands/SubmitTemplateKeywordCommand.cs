using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.TemplateKeyword.Commands
{
    public class SubmitTemplateKeywordCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("keyword_code")]
        public string KeywordCode { get; set; } = null!;

        [JsonPropertyName("keyword_name")]
        public string KeywordName { get; set; } = null!;

        [JsonPropertyName("static_value")]
        public bool StaticValue { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        [JsonPropertyName("table_name")]
        public string? TableName { get; set; }

        [JsonPropertyName("column_name")]
        public string? ColumnName { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
