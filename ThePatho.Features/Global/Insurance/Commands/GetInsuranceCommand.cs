using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Insurance.DTO;

namespace ThePatho.Features.Global.Insurance.Commands
{
    public class GetInsuranceCommand : IRequest<ApiResponse<InsuranceItemDto>>
    {
        [JsonPropertyName("filter_InsuranceName")]
        public string? FilterInsuranceName { get; set; }

        [JsonPropertyName("filter_InsuranceCode")]
        public string? FilterInsuranceCode { get; set; }

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





