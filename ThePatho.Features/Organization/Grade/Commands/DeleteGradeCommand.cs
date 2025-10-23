using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Grade.Commands
{
    public class DeleteGradeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("grade_code")]
        public string GradeCode { get; set; } = null!;
    }
}
