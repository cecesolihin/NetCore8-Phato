using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsCategory.DTO;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsCategoryDdlCommand : IRequest<ApiResponse<AdsCategoryItemDto>>
    {
        [JsonPropertyName("filter_AdsCategoryCode")] 
        public string? FilterAdsCategoryCode { get; set; }
        [JsonPropertyName("filter_AdsCategoryName")]
        public string? FilterAdsCategoryName { get; set; }
       
    }
}
