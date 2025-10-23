using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePickUp.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeePickUp.Commands
{
    public class GetEmployeePickUpByCriteriaCommand : IRequest<ApiResponse<EmployeePickUpItemDto>>
    {
        [JsonPropertyName("filter_PickUpId")]
        public byte? FilterPickUpId { get; set; }

        [JsonPropertyName("filter_PickUpLocation")]
        public string? FilterPickUpLocation { get; set; }
    }
}

