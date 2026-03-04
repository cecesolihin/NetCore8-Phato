using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MedicalGroup.DTO;

namespace ThePatho.Features.Global.MedicalGroup.Commands
{
    public class GetMedicalGroupByCriteriaCommand : IRequest<ApiResponse<MedicalGroupItemDto>>
    {
        [JsonPropertyName("medicalGroupName")]
        public string? MedicalGroupName { get; set; }

        [JsonPropertyName("medicalGroupCode")]
        public string? MedicalGroupCode { get; set; }
    }
}
