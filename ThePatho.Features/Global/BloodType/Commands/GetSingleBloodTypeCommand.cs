using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BloodType.DTO;

namespace ThePatho.Features.Global.BloodType.Commands
{
    public class GetSingleBloodTypeCommand : IRequest<ApiResponse<BloodTypeDto>>
    {
        [JsonPropertyName("filter_BloodTypeCode")]
        public string FilterBloodTypeCode { get; set; } = null!;
    }
}
