using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.EduLevel.Commands
{
    public class DeleteEduLevelCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("edu_level_code")]
        public string? EduLevelCode { get; set; }
    }
}

