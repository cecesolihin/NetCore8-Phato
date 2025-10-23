using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyBank.DTO;

namespace ThePatho.Features.Organization.CompanyBank.Commands
{
    public class GetCompanyBankByCriteriaCommand : IRequest<ApiResponse<CompanyBankItemDto>>
    {
        [JsonPropertyName("filter_CompanyCode")]
        public string? FilterCompanyCode { get; set; }

        [JsonPropertyName("filter_BankCode")]
        public string? FilterBankCode { get; set; }

        [JsonPropertyName("filter_Branch")]
        public string? FilterBranch { get; set; }

        [JsonPropertyName("filter_AccountName")]
        public string? FilterAccountName { get; set; }

    }
}
