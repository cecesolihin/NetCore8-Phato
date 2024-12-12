using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ThePatho.Features.MasterData.AdsCategory.DTO;
using ThePatho.Features.MasterData.AdsMedia.DTO;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetAdsMediaByCodeCommand : IRequest<AdsMediaDto>
    {
        [JsonPropertyName("filter_AdsCode")]
        public string? FilterAdsCode { get; set; }
        
    }
}
