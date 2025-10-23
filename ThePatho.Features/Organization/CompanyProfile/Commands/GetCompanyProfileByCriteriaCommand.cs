using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyProfile.DTO;

namespace ThePatho.Features.Organization.CompanyProfile.Commands
{
    public class GetCompanyProfileByCriteriaCommand : IRequest<ApiResponse<CompanyProfileItemDto>>
    {
        [JsonPropertyName("filter_company_code")]
        public string FilterCompanyCode { get; set; } = null!;

        [JsonPropertyName("filter_company_name")]
        public string FilterCompanyName { get; set; } = null!;

        [JsonPropertyName("filter_country_code")]
        public string? FilterCountryCode { get; set; }

        [JsonPropertyName("filter_city")]
        public string? FilterCity { get; set; }

    }
}
