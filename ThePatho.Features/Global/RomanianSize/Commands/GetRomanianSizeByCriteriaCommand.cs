using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RomanianSize.DTO;

namespace ThePatho.Features.Global.RomanianSize.Commands
{
    public class GetRomanianSizeByCriteriaCommand : IRequest<ApiResponse<RomanianSizeItemDto>>
    {
        [JsonPropertyName("filter_RomanianSizeName")]
        public string? FilterRomanianSizeName { get; set; }


    }
}
