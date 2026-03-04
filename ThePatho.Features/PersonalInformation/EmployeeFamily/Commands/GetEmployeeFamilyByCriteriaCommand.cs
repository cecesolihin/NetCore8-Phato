using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeFamily.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeFamily.Commands
{
    public class GetEmployeeFamilyByCriteriaCommand : IRequest<ApiResponse<EmployeeFamilyItemDto>>
    {
        [JsonPropertyName("employeeId")]
        public int? EmployeeId { get; set; }

        [JsonPropertyName("relationCode")]
        public string? RelationCode { get; set; }

        [JsonPropertyName("familyName")]
        public string? FamilyName { get; set; }
    }
}

