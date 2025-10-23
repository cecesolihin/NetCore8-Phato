using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeePickUp.Commands
{
    public class DeleteEmployeePickUpCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("filter_PickUpId")]
        public byte FilterPickUpId { get; set; }
    }
}

