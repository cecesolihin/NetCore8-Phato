using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.GraduationType.Commands
{
    public class DeleteGraduationTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("grad_type_code")]
        public string GradTypeCode { get; set; }
    }
}


