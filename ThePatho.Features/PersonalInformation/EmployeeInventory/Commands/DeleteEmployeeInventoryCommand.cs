using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Commands
{
    public class DeleteEmployeeInventoryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("inventory_no")]
        public string InventoryNo { get; set; } = null!;
    }
}

