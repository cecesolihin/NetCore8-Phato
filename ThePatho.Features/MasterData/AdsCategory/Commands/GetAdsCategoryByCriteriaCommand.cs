using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.AdsCategory.DTO;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsCategoryByCriteriaCommand : IRequest<ApiResponse<AdsCategoryDto>>
    {
        [JsonPropertyName("filter_AdsCategoryCode")] 
        public string? FilterAdsCategoryCode { get; set; }
        
    }
}
