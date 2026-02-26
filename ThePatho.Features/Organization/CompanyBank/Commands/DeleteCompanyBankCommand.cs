using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.CompanyBank.Commands
{
    public class DeleteCompanyBankCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("companyBankId")]
        public int CompanyBankId { get; set; }
    }
}
