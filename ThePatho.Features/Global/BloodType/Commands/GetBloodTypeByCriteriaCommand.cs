using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BloodType.DTO;

namespace ThePatho.Features.Global.BloodType.Commands
{
    public class GetBloodTypeByCriteriaCommand : IRequest<ApiResponse<BloodTypeItemDto>>
    {
        [JsonPropertyName("bloodTypeCode")]
        public string? BloodTypeCode { get; set; }
        [JsonPropertyName("bloodTypeName")]
        public string? BloodTypeName { get; set; }

    }
}
