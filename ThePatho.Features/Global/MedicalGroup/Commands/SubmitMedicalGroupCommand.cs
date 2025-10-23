using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.MedicalGroup.Commands
{
    public class SubmitMedicalGroupCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("medical_group_code")]
        public string MedicalGroupCode { get; set; } = null!;

        [JsonPropertyName("medical_group_name")]
        public string MedicalGroupName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
