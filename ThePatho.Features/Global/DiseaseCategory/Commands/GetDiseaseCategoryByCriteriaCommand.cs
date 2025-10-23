using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DiseaseCategory.DTO;

namespace ThePatho.Features.Global.DiseaseCategory.Commands
{
    public class GetDiseaseCategoryByCriteriaCommand : IRequest<ApiResponse<DiseaseCategoryItemDto>>
    {
        [JsonPropertyName("filter_DiseaseCategoryCode")]
        public string? FilterDiseaseCategoryCode { get; set; }

        [JsonPropertyName("filter_DiseaseCategoryName")]
        public string? FilterDiseaseCategoryName { get; set; }
    }
}

