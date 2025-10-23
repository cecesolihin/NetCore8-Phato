using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeePickUp.Commands
{
    public class SubmitEmployeePickUpCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("pick_up_id")]
        public byte PickUpId { get; set; }

        [JsonPropertyName("pick_up_location")]
        public string PickUpLocation { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

