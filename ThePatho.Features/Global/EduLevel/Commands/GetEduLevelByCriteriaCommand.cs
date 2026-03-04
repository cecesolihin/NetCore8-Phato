using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduLevel.DTO;

namespace ThePatho.Features.Global.EduLevel.Commands
{
    public class GetEduLevelByCriteriaCommand : IRequest<ApiResponse<EduLevelItemDto>>
    {
        [JsonPropertyName("eduLevelCode")]
        public string? EduLevelCode { get; set; }

        [JsonPropertyName("eduLevelName")]
        public string? EduLevelName { get; set; }
    }
}

