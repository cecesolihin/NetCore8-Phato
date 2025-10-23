using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Commands
{
    public class SubmitEmployeeInventoryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("inventory_no")]
        public string InventoryNo { get; set; } = null!;

        [JsonPropertyName("inventory_type_code")]
        public string InventoryTypeCode { get; set; } = null!;

        [JsonPropertyName("inventory_name")]
        public string InventoryName { get; set; } = null!;

        [JsonPropertyName("received_date")]
        public string? ReceivedDate { get; set; }

        [JsonPropertyName("return_plan_date")]
        public string? ReturnPlanDate { get; set; }

        [JsonPropertyName("qty")]
        public short Qty { get; set; }

        [JsonPropertyName("size")]
        public string Size { get; set; } = null!;

        [JsonPropertyName("in_condition")]
        public string InCondition { get; set; } = null!;

        [JsonPropertyName("in_remark")]
        public string InRemark { get; set; } = null!;

        [JsonPropertyName("return_date")]
        public string? ReturnDate { get; set; }

        [JsonPropertyName("out_condition")]
        public string OutCondition { get; set; } = null!;

        [JsonPropertyName("out_remark")]
        public string OutRemark { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

