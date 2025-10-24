using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Insurance.Commands
{
    public class SubmitInsuranceCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("insurance_code")]
        public string InsuranceCode { get; set; } = null!;

        [JsonPropertyName("insurance_name")]
        public string? InsuranceName { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}




