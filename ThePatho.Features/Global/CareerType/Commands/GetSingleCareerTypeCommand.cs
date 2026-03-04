using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.CareerType.DTO;

namespace ThePatho.Features.Global.CareerType.Commands
{
    public class GetSingleCareerTypeCommand : IRequest<ApiResponse<CareerTypeDto>>
    {
        [JsonPropertyName("filter_CareerTypeCode")]
        public string? FilterCareerTypeCode { get; set; }
    }
}
