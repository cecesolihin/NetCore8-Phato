using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryCondition.Commands
{
    public class DeleteInventoryConditionCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("inventory_condition_code")]
        public string InventoryConditionCode { get; set; }
    }
}


