using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCapColor.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeCapColor.Commands
{
    public class GetEmployeeCapColorByCriteriaCommand : IRequest<ApiResponse<EmployeeCapColorItemDto>>
    {
        [JsonPropertyName("filter_color_name")]
        public string? FilterColorName { get; set; }
    }
}

