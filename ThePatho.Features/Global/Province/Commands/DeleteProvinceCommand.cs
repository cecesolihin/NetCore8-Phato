using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Province.Commands
{
    public class DeleteProvinceCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("province_id")]
        public int ProvinceId { get; set; }
    }
}
