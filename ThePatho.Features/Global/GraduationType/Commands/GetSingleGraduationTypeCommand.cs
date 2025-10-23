using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.GraduationType.DTO;

namespace ThePatho.Features.Global.GraduationType.Commands
{
    public class GetSingleGraduationTypeCommand : IRequest<ApiResponse<GraduationTypeDto>>
    {
        [JsonPropertyName("filter_GradTypeCode")]
        public string FilterGradTypeCode { get; set; }
    }
}
