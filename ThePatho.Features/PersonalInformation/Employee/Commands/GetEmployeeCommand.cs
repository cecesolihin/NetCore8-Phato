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
        public string FilterFullname { get; set; } = null!;
        [JsonPropertyName("filter_job_class_code")]
        public string? FilterJobClassCode { get; set; }

        [JsonPropertyName("filter_employment_type_code")]
        public string? FilterEmploymentTypeCode { get; set; }

        [JsonPropertyName("filter_PositionCode")]
        public string FilterPositionCode { get; set; } = null!;
        [JsonPropertyName("filter_WorkLocationCode")]
        public string? FilterWorkLocationCode { get; set; }

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

