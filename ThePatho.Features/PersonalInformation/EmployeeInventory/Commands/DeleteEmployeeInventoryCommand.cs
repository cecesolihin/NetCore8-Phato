using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Commands
{
    public class DeleteEmployeeInventoryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("inventoryNo")]
        public string InventoryNo { get; set; } = null!;
    }
}

