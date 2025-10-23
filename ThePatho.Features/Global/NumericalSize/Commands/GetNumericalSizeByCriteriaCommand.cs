using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.NumericalSize.DTO;

namespace ThePatho.Features.Global.NumericalSize.Commands
{
    public class GetNumericalSizeByCriteriaCommand : IRequest<ApiResponse<NumericalSizeItemDto>>
    {
        [JsonPropertyName("filter_NumericalSizeName")]
        public string? FilterNumericalSizeName { get; set; }


    }
}
