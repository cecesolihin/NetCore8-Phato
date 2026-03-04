using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.Employee.DTO;

namespace ThePatho.Features.PersonalInformation.Employee.Commands
{
    public class GetEmployeeByCriteriaCommand : IRequest<ApiResponse<EmployeeItemDto>>
    {
        [JsonPropertyName("employeeNo")]
        public string? EmployeeNo { get; set; }

        [JsonPropertyName("fullname")]
        public string? Fullname { get; set; } = null!;
        [JsonPropertyName("jobClass")]
        public string? JobClass { get; set; }

        [JsonPropertyName("employmentType")]
        public string? EmploymentType { get; set; }

        [JsonPropertyName("position")]
        public string? Position { get; set; } = null!;
        [JsonPropertyName("workLocation")]
        public string? WorkLocation { get; set; }
    }
}

