using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryGroup.Commands
{
    public class DeleteInventoryGroupCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("inventory_group_code")]
        public string? InventoryGroupCode { get; set; }
    }
}

