using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Grade.DTO;

namespace ThePatho.Features.Organization.Grade.Commands
{
    public class GetSingleGradeCommand : IRequest<ApiResponse<GradeDto>>
    {
        [JsonPropertyName("grade_code")]
        public string GradeCode { get; set; } = null!;
    }
}
