using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.GraduationType.Commands
{
    public class SubmitGraduationTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("grad_type_code")]
        public string GradTypeCode { get; set; } = null!;

        [JsonPropertyName("grad_type_name")]
        public string GradTypeName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}


