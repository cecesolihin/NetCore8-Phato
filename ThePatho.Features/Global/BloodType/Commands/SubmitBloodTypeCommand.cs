using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.BloodType.Commands
{
    public class SubmitBloodTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("blood_type_code")]
        public string BloodTypeCode { get; set; } = null!;

        [JsonPropertyName("blood_type_name")]
        public string BloodTypeName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
