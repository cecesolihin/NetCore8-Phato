using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyBank.DTO;

namespace ThePatho.Features.Organization.CompanyBank.Commands
{
    public class GetCompanyBankCommand : IRequest<ApiResponse<CompanyBankItemDto>>
    {
        [JsonPropertyName("filter_CompanyCode")]
        public string? FilterCompanyCode { get; set; }

        [JsonPropertyName("filter_BankCode")]
        public string? FilterBankCode { get; set; }

        [JsonPropertyName("filter_Branch")]
        public string? FilterBranch { get; set; }

        [JsonPropertyName("filter_AccountName")]
        public string? FilterAccountName { get; set; }

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
