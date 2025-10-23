using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DiseaseCategory.DTO;

namespace ThePatho.Features.Global.DiseaseCategory.Commands
{
    public class GetDiseaseCategoryCommand : IRequest<ApiResponse<DiseaseCategoryItemDto>>
    {
        [JsonPropertyName("filter_DiseaseCategoryCode")]
        public string? FilterDiseaseCategoryCode { get; set; }

        [JsonPropertyName("filter_DiseaseCategoryName")]
        public string? FilterDiseaseCategoryName { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}

