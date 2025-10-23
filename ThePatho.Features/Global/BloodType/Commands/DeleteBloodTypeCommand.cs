using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.BloodType.Commands
{
    public class DeleteBloodTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("blood_type_code")]
        public string BloodTypeCode { get; set; } = null!;
    }
}
