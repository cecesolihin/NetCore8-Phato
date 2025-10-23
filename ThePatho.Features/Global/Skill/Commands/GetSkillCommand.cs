using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Skill.DTO;

namespace ThePatho.Features.Global.Skill.Commands
{
    public class GetSkillCommand : IRequest<ApiResponse<SkillItemDto>>
    {
        [JsonPropertyName("filter_SkillName")]
        public string? FilterSkillName { get; set; }

        [JsonPropertyName("filter_SkillCode")]
        public string? FilterSkillCode { get; set; }

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
