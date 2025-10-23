using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduMajor.DTO;

namespace ThePatho.Features.Global.EduMajor.Commands
{
    public class GetEduMajorCommand : IRequest<ApiResponse<EduMajorItemDto>>
    {
        [JsonPropertyName("filter_MajorCode")]
        public string? FilterMajorCode { get; set; }

        [JsonPropertyName("filter_MajorName")]
        public string? FilterMajorName { get; set; }

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

