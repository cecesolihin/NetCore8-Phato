using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryType.Commands
{
    public class SubmitInventoryTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("inventory_type_code")]
        public string InventoryTypeCode { get; set; } = null!;

        [JsonPropertyName("inventory_name")]
        public string InventoryName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
