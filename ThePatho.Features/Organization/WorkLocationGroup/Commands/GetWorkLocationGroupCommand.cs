using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocationGroup.DTO;

namespace ThePatho.Features.Organization.WorkLocationGroup.Commands
{
    public class GetWorkLocationGroupCommand : IRequest<ApiResponse<WorkLocationGroupItemDto>>
    {
        [JsonPropertyName("filter_group_id")]
        public int? FilterGroupId { get; set; }

        [JsonPropertyName("filter_work_location_code")]
        public string? FilterWorkLocationCode { get; set; }

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
