using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MedicalGroup.DTO;

namespace ThePatho.Features.Global.MedicalGroup.Commands
{
    public class GetMedicalGroupByCriteriaCommand : IRequest<ApiResponse<MedicalGroupItemDto>>
    {
        [JsonPropertyName("filter_MedicalGroupName")]
        public string? FilterMedicalGroupName { get; set; }

        [JsonPropertyName("filter_MedicalGroupCode")]
        public string? FilterMedicalGroupCode { get; set; }
    }
}
