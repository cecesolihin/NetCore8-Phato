using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeCapColor.Commands
{
    public class DeleteEmployeeCapColorCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("cap_color_id")]
        public byte CapColorId { get; set; }
    }
}

