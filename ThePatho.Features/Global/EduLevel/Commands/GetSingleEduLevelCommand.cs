using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduLevel.DTO;

namespace ThePatho.Features.Global.EduLevel.Commands
{
    public class GetSingleEduLevelCommand : IRequest<ApiResponse<EduLevelDto>>
    {
        [JsonPropertyName("filter_EduLevelCode")]
        public string? EduLevelCode { get; set; }

    }
}
