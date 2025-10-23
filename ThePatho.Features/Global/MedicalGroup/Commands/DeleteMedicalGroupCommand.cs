using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.MedicalGroup.Commands
{
    public class DeleteMedicalGroupCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("medical_group_code")]
        public string MedicalGroupCode { get; set; } = null!;
    }
}
