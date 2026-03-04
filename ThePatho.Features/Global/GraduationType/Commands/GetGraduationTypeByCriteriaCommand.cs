using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.GraduationType.DTO;

namespace ThePatho.Features.Global.GraduationType.Commands
{
    public class GetGraduationTypeByCriteriaCommand : IRequest<ApiResponse<GraduationTypeItemDto>>
    {
        [JsonPropertyName("gradTypeName")]
        public string? GradTypeName { get; set; }

        [JsonPropertyName("gradTypeCode")]
        public string? GradTypeCode { get; set; }

    }
}





