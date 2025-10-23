using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeFamily.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeFamily.Commands
{
    public class GetEmployeeFamilyByCriteriaCommand : IRequest<ApiResponse<EmployeeFamilyItemDto>>
    {
        [JsonPropertyName("filter_employee_id")]
        public int? FilterEmployeeId { get; set; }

        [JsonPropertyName("filter_relation_code")]
        public string? FilterRelationCode { get; set; }

        [JsonPropertyName("filter_family_name")]
        public string? FilterFamilyName { get; set; }
    }
}

