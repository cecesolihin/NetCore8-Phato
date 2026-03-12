using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.Employee.DTO;

namespace ThePatho.Features.PersonalInformation.Employee.Commands
{
    public class GetEmployeeCommand : IRequest<ApiResponse<EmployeeItemDto>>
    {
        [JsonPropertyName("filter_employee")]
        public string? FilterEmployee { get; set; }

        [JsonPropertyName("filter_joinDateFrom")]
        public DateTime? FilterJoinDateFrom { get; set; }

        [JsonPropertyName("filter_joinDateTo")]
        public DateTime? FilterJoinDateTo { get; set; }
        [JsonPropertyName("filter_terminateDateFrom")]
        public DateTime? FilterTerminateDateFrom { get; set; }

        [JsonPropertyName("filter_terminateDateTo")]
        public DateTime? FilterTerminateDateTo { get; set; }

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

