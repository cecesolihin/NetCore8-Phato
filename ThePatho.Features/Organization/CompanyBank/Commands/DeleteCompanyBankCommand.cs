using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.CompanyBank.Commands
{
    public class DeleteCompanyBankCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("company_bank_id")]
        public int CompanyBankId { get; set; }
    }
}
