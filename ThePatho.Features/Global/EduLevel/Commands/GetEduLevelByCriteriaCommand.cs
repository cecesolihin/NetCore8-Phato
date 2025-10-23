using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduLevel.DTO;

namespace ThePatho.Features.Global.EduLevel.Commands
{
    public class GetEduLevelByCriteriaCommand : IRequest<ApiResponse<EduLevelItemDto>>
    {
        [JsonPropertyName("filter_EduLevelCode")]
        public string? FilterEduLevelCode { get; set; }

        [JsonPropertyName("filter_EduLevelName")]
        public string? FilterEduLevelName { get; set; }
    }
}

