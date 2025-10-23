using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeInventory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Commands
{
    public class GetEmployeeInventoryByCriteriaCommand : IRequest<ApiResponse<EmployeeInventoryItemDto>>
    {
        [JsonPropertyName("filter_inventory_name")]
        public string? FilterInventoryName { get; set; }

        [JsonPropertyName("filter_inventory_no")]
        public string? FilterInventoryNo { get; set; }

        [JsonPropertyName("filter_inventory_type_code")]
        public string? FilterInventoryTypeCode { get; set; }

        [JsonPropertyName("filter_employee_id")]
        public int? FilterEmployeeId { get; set; }
    }
}

