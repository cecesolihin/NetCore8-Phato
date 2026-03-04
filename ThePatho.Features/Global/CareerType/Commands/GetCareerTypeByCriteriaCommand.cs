using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.CareerType.DTO;

namespace ThePatho.Features.Global.CareerType.Commands
{
    public class GetCareerTypeByCriteriaCommand : IRequest<ApiResponse<CareerTypeItemDto>>
    {
        [JsonPropertyName("careerTypeName")]
        public string? CareerTypeName { get; set; }

        [JsonPropertyName("careerTypeCode")]
        public string? CareerTypeCode { get; set; }

    }
}





