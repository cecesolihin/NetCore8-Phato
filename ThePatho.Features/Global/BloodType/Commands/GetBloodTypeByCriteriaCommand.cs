using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BloodType.DTO;

namespace ThePatho.Features.Global.BloodType.Commands
{
    public class GetBloodTypeByCriteriaCommand : IRequest<ApiResponse<BloodTypeItemDto>>
    {
        [JsonPropertyName("filter_BloodTypeCode")]
        public string? FilterBloodTypeCode { get; set; }
        [JsonPropertyName("filter_BloodTypeName")]
        public string? FilterBloodTypeName { get; set; }

    }
}
