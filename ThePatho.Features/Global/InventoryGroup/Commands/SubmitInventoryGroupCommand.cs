using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryGroup.Commands
{
    public class SubmitInventoryGroupCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("inventory_group_code")]
        public string? InventoryGroupCode { get; set; }

        [JsonPropertyName("inventory_group_name")]
        public string? InventoryGroupName { get; set; }

        [JsonPropertyName("group_by")]
        public string? GroupBy { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

