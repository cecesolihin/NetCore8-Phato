using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeInventory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Commands
{
    public class GetSingleEmployeeInventoryCommand : IRequest<ApiResponse<EmployeeInventoryDto>>
    {
        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("inventory_no")]
        public string InventoryNo { get; set; } = null!;

    }
}
