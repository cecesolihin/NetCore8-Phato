using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.DiseaseCategory.Commands
{
    public class SubmitDiseaseCategoryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("disease_category_code")]
        public string? DiseaseCategoryCode { get; set; }

        [JsonPropertyName("disease_category_name")]
        public string? DiseaseCategoryName { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

