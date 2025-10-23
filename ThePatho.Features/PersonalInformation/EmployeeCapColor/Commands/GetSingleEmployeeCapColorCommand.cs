using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCapColor.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeCapColor.Commands
{
    public class GetSingleEmployeeCapColorCommand : IRequest<ApiResponse<EmployeeCapColorDto>>
    {
        [JsonPropertyName("cap_color_id")]
        public byte CapColorId { get; set; }

    }
}
