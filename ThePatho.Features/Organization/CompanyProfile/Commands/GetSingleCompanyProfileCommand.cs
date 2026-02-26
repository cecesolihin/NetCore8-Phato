using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyProfile.DTO;

namespace ThePatho.Features.Organization.CompanyProfile.Commands
{
    public class GetSingleCompanyProfileCommand : IRequest<ApiResponse<CompanyProfileDto>>
    {
        [JsonPropertyName("companyCode")]
        public string CompanyCode { get; set; } = null!;
    }
}
