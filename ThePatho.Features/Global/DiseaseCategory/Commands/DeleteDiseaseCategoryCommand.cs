using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.DiseaseCategory.Commands
{
    public class DeleteDiseaseCategoryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("disease_category_code")]
        public string? DiseaseCategoryCode { get; set; }
    }
}

