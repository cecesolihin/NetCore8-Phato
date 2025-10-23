using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeCapColor.Commands
{
    public class SubmitEmployeeCapColorCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("cap_color_id")]
        public byte CapColorId { get; set; }

        [JsonPropertyName("color_name")]
        public string ColorName { get; set; } = null!;

        [JsonPropertyName("inserted_by")]
        public string? InsertedBy { get; set; }

        [JsonPropertyName("inserted_date")]
        public string? InsertedDate { get; set; }

        [JsonPropertyName("modified_by")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("modified_date")]
        public string? ModifiedDate { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

