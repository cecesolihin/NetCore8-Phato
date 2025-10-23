using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxStatus.DTO;

namespace ThePatho.Features.Global.TaxStatus.Commands
{
    public class GetTaxStatusCommand : IRequest<ApiResponse<TaxStatusItemDto>>
    {
        [JsonPropertyName("filter_TaxStatusName")]
        public string? FilterTaxStatusName { get; set; }

        [JsonPropertyName("filter_TaxStatusCode")]
        public string? FilterTaxStatusCode { get; set; }
        [JsonPropertyName("filter_Married")]
        public string? FilterMarried { get; set; }
        [JsonPropertyName("filter_TotalDependents")]
        public int? FilterTotalDependents { get; set; }

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
