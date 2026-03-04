using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DiseaseCategory.DTO;

namespace ThePatho.Features.Global.DiseaseCategory.Commands
{
    public class GetDiseaseCategoryByCriteriaCommand : IRequest<ApiResponse<DiseaseCategoryItemDto>>
    {
        [JsonPropertyName("diseaseCategoryCode")]
        public string? DiseaseCategoryCode { get; set; }

        [JsonPropertyName("diseaseCategoryName")]
        public string? DiseaseCategoryName { get; set; }
    }
}

