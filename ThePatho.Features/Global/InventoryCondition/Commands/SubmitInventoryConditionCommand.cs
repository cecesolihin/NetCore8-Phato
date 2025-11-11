using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryCondition.Commands
{
    public class SubmitInventoryConditionCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("inventory_condition_code")]
        public string InventoryConditionCode { get; set; } = null!;

        [JsonPropertyName("inventory_condition_name")]
        public string InventoryConditionName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}





