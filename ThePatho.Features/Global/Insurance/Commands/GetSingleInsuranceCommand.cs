using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Insurance.DTO;

namespace ThePatho.Features.Global.Insurance.Commands
{
    public class GetSingleInsuranceCommand : IRequest<ApiResponse<InsuranceDto>>
    {
        [JsonPropertyName("filter_InsuranceCode")]
        public string? FilterInsuranceCode { get; set; }
    }
}
