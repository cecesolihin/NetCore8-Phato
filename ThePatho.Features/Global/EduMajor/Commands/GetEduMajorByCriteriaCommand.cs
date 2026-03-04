using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduMajor.DTO;

namespace ThePatho.Features.Global.EduMajor.Commands
{
    public class GetEduMajorByCriteriaCommand : IRequest<ApiResponse<EduMajorItemDto>>
    {
        [JsonPropertyName("majorCode")]
        public string? MajorCode { get; set; }

        [JsonPropertyName("majorName")]
        public string? MajorName { get; set; }
    }
}

