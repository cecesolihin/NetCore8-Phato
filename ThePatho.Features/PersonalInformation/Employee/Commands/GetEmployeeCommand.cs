using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.Employee.DTO;

namespace ThePatho.Features.PersonalInformation.Employee.Commands
{
    public class GetEmployeeCommand : IRequest<ApiResponse<EmployeeItemDto>>
    {
        [JsonPropertyName("filter_EmployeeNo")]
        public string? FilterEmployeeNo { get; set; }

        [JsonPropertyName("filter_Fullname")]
        public string? FilterFullname { get; set; } = null!;
        [JsonPropertyName("filter_JobClass")]
        public string? FilterJobClass { get; set; }

        [JsonPropertyName("filter_EmploymentType")]
        public string? FilterEmploymentType { get; set; }

        [JsonPropertyName("filter_Position")]
        public string? FilterPosition { get; set; } = null!;
        [JsonPropertyName("filter_WorkLocation")]
        public string? FilterWorkLocation { get; set; }

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

