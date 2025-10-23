using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduMajor.DTO;

namespace ThePatho.Features.Global.EduMajor.Commands
{
    public class GetEduMajorByCriteriaCommand : IRequest<ApiResponse<EduMajorItemDto>>
    {
        [JsonPropertyName("filter_MajorCode")]
        public string? FilterMajorCode { get; set; }

        [JsonPropertyName("filter_MajorName")]
        public string? FilterMajorName { get; set; }
    }
}

