using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Commands
{
    public class SubmitEmployeeInventoryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("inventoryNo")]
        public string InventoryNo { get; set; } = null!;

        [JsonPropertyName("inventoryTypeCode")]
        public string InventoryTypeCode { get; set; } = null!;

        [JsonPropertyName("inventoryTypeName")]
        public string InventoryTypeName { get; set; } = null!;

        [JsonPropertyName("receivedDate")]
        public string? ReceivedDate { get; set; }

        [JsonPropertyName("returnPlanDate")]
        public string? ReturnPlanDate { get; set; }

        [JsonPropertyName("receivedQty")]
        public short ReceivedQty { get; set; }

        [JsonPropertyName("size")]
        public string Size { get; set; } = null!;

        [JsonPropertyName("receivedCondition")]
        public string ReceivedCondition { get; set; } = null!;

        [JsonPropertyName("receivedRemark")]
        public string ReceivedRemark { get; set; } = null!;

        [JsonPropertyName("returnDate")]
        public string? ReturnDate { get; set; }

        [JsonPropertyName("ReturnCondition")]
        public string ReturnCondition { get; set; } = null!;

        [JsonPropertyName("ReturnRemark")]
        public string ReturnRemark { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

