using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Insurance.Commands
{
    public class DeleteInsuranceCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("insurance_code")]
        public string? InsuranceCode { get; set; }
    }
}


