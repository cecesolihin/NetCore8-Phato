using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.EduMajor.Commands
{
    public class DeleteEduMajorCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("major_code")]
        public string? MajorCode { get; set; }
    }
}

