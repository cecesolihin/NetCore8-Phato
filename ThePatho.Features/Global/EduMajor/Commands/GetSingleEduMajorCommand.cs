using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduMajor.DTO;

namespace ThePatho.Features.Global.EduMajor.Commands
{
    public class GetSingleEduMajorCommand : IRequest<ApiResponse<EduMajorDto>>
    {
        [JsonPropertyName("major_code")]
        public string? MajorCode { get; set; }

    }
}
