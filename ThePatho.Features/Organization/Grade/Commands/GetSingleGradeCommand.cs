using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Grade.DTO;

namespace ThePatho.Features.Organization.Grade.Commands
{
    public class GetSingleGradeCommand : IRequest<ApiResponse<GradeDto>>
    {
        [JsonPropertyName("gradeCode")]
        public string GradeCode { get; set; } = null!;
    }
}
