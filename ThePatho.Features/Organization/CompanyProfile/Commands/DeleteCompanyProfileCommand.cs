using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.CompanyProfile.Commands
{
    public class DeleteCompanyProfileCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("company_code")]
        public string CompanyCode { get; set; } = null!;
    }
}
