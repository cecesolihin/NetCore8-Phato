using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.DTO;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class GetSuperiorSubordinateCommand : IRequest<ApiResponse<SuperiorSubordinateItemDto>>
    {
        [JsonPropertyName("filter_employeeId")]
        public int? FilterEmployee { get; set; }

        [JsonPropertyName("filter_superior")]
        public string? FilterSuperior { get; set; }
        [JsonPropertyName("filter_effectiveDateFrom")]
        public DateTime? FilterEffectiveDateFrom { get; set; }
        [JsonPropertyName("filter_effectiveDateTo")]
        public DateTime? FilterEffectiveDateTo { get; set; }
        //[JsonPropertyName("filter_status")]
        //public string? FilterStatus { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "ASC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}

