using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyProfile.DTO;

namespace ThePatho.Features.Organization.CompanyProfile.Commands
{
    public class GetCompanyProfileCommand : IRequest<ApiResponse<CompanyProfileItemDto>>
    {
        [JsonPropertyName("filter_company_code")]
        public string FilterCompanyCode { get; set; } = null!;

        [JsonPropertyName("filter_company_name")]
        public string FilterCompanyName { get; set; } = null!;

        [JsonPropertyName("filter_country_code")]
        public string? FilterCountryCode { get; set; }

        [JsonPropertyName("filter_city")]
        public string? FilterCity { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(0)]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}
