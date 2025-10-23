using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.DTO;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class GetSuperiorSubordinateByCriteriaCommand : IRequest<ApiResponse<SuperiorSubordinateItemDto>>
    {
        [JsonPropertyName("filter_EmployeeId")]
        public int? FilterEmployeeId { get; set; }

        [JsonPropertyName("filter_EffectiveDate")]
        public string? FilterEffectiveDate { get; set; }

        [JsonPropertyName("filter_Superior")]
        public string? FilterSuperior { get; set; }
        [JsonPropertyName("filter_Status")]
        public string? FilterStatus { get; set; }
    }
}

