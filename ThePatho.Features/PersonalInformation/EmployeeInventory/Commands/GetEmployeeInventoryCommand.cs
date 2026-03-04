using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeInventory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Commands
{
    public class GetEmployeeInventoryCommand : IRequest<ApiResponse<EmployeeInventoryItemDto>>
    {
        [JsonPropertyName("filter_employeeId")]
        public int? FilterEmployeeId { get; set; }
        [JsonPropertyName("filter_inventory")]
        public string? FilterInventory { get; set; }

        [JsonPropertyName("filter_receivedDateFrom")]
        public DateTime? FilterReceivedDateFrom { get; set; }

        [JsonPropertyName("filter_receivedDateTo")]
        public DateTime? FilterReceivedDateTo { get; set; }

        [JsonPropertyName("filter_returnDateFrom")]
        public DateTime? FilterReturnDateFrom { get; set; }
        [JsonPropertyName("filter_returnDateTo")]
        public DateTime? FilterReturnDateTo { get; set; }
        [JsonPropertyName("filter_returnPlanDateFrom")]
        public DateTime? FilterReturnPlanDateFrom { get; set; }
        [JsonPropertyName("filter_returnPlanDateTo")]
        public DateTime? FilterReturnPlanDateTo { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}

