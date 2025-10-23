using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryType.DTO;

namespace ThePatho.Features.Global.InventoryType.Commands
{
    public class GetSingleInventoryTypeCommand : IRequest<ApiResponse<InventoryTypeDto>>
    {
        [JsonPropertyName("filter_InventoryTypeCode")]
        public string FilterInventoryTypeCode { get; set; }
    }
}
