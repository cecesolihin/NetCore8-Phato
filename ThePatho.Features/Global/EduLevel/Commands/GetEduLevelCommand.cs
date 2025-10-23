using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduLevel.DTO;

namespace ThePatho.Features.Global.EduLevel.Commands
{
    public class GetEduLevelCommand : IRequest<ApiResponse<EduLevelItemDto>>
    {
        [JsonPropertyName("filter_EduLevelCode")]
        public string? FilterEduLevelCode { get; set; }

        [JsonPropertyName("filter_EduLevelName")]
        public string? FilterEduLevelName { get; set; }

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

