using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.AdsCategory.DTO;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsCategoryByCriteriaCommand : IRequest<NewApiResponse<AdsCategoryDto>>
    {
        [JsonPropertyName("filter_AdsCategoryCode")] 
        public string? FilterAdsCategoryCode { get; set; }
        
    }
}
