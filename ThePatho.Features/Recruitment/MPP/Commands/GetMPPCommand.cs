using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Recruitment.MPP.DTO;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class GetMPPCommand :IRequest<MPPItemDto>
    {
        [JsonPropertyName("filter_MppNo")]
        public string? FilterMppNo { get; set; }
        [JsonPropertyName("filter_PeriodCode")]
        public string? FilterPeriodCode { get; set; }
        [JsonPropertyName("filter_Year")]
        public string? FilterYear { get; set; }
        [JsonPropertyName("sortBy")]
        public string? SortBy { get; set; } = "InsertedDate";
        [JsonPropertyName("orderBy")]
        public string? OrderBy { get; set; } = "DESC";
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; } = 0;
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 10; 
    }
}
