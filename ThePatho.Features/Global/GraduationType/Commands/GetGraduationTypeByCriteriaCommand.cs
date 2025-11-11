using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.GraduationType.DTO;

namespace ThePatho.Features.Global.GraduationType.Commands
{
    public class GetGraduationTypeByCriteriaCommand : IRequest<ApiResponse<GraduationTypeItemDto>>
    {
        [JsonPropertyName("filter_GradTypeName")]
        public string? FilterGradTypeName { get; set; }

        [JsonPropertyName("filter_GradTypeCode")]
        public string? FilterGradTypeCode { get; set; }

    }
}





