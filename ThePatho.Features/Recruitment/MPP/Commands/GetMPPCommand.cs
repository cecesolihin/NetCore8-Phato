using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.MPP.DTO;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class GetMPPCommand :IRequest<ApiResponse<MPPItemDto>>
    {
        [JsonPropertyName("filter_MppNo")]
        public string? FilterMppNo { get; set; }

        [JsonPropertyName("filter_PeriodCode")]
        public string? FilterPeriodCode { get; set; }

        [JsonPropertyName("filter_Year")]
        public string? FilterYear { get; set; }

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
