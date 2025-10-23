using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryType.Commands
{
    public class DeleteInventoryTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("inventory_type_code")]
        public string InventoryTypeCode { get; set; }
    }
}
