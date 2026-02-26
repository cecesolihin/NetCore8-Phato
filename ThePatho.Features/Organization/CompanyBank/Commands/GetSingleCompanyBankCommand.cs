using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyBank.DTO;

namespace ThePatho.Features.Organization.CompanyBank.Commands
{
    public class GetSingleCompanyBankCommand : IRequest<ApiResponse<CompanyBankDto>>
    {
        [JsonPropertyName("companyBankId")]
        public int CompanyBankId { get; set; }

    }
}
