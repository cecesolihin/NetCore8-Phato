using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeInventory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Commands
{
    public class GetEmployeeInventoryByCriteriaCommand : IRequest<ApiResponse<EmployeeInventoryItemDto>>
    {
        [JsonPropertyName("inventoryName")]
        public string? InventoryName { get; set; }

        [JsonPropertyName("inventoryNo")]
        public string? InventoryNo { get; set; }

        [JsonPropertyName("inventoryTypeCode")]
        public string? InventoryTypeCode { get; set; }

        [JsonPropertyName("employeeId")]
        public int? EmployeeId { get; set; }
    }
}

