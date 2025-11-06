using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.Employee.DTO;

namespace ThePatho.Features.PersonalInformation.Employee.Commands
{
    public class GetEmployeeByCriteriaCommand : IRequest<ApiResponse<EmployeeItemDto>>
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
    }
}

