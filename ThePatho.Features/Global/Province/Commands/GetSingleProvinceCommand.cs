using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Province.DTO;

namespace ThePatho.Features.Global.Province.Commands
{
    public class GetSingleProvinceCommand : IRequest<ApiResponse<ProvinceDto>>
    {
        [JsonPropertyName("filter_ProvinceId")]
        public int FilterProvinceId { get; set; }
    }
}
