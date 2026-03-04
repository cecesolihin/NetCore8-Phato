using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.DTO;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class GetSuperiorSubordinateByCriteriaCommand : IRequest<ApiResponse<SuperiorSubordinateItemDto>>
    {
        [JsonPropertyName("employee")]
        public string? Employee { get; set; }

        [JsonPropertyName("effectiveDate")]
        public string? FffectiveDate { get; set; }

        [JsonPropertyName("superior")]
        public string? Superior { get; set; }
        [JsonPropertyName("status")]
        public string? Status { get; set; }
    }
}

