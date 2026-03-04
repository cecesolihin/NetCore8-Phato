using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeMedical.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Commands
{
    public class GetEmployeeMedicalByCriteriaCommand : IRequest<ApiResponse<EmployeeMedicalItemDto>>
    {
        [JsonPropertyName("employeeId")]
        public int? EmployeeId { get; set; }

        [JsonPropertyName("diseaseName")]
        public string? DiseaseName { get; set; }

        [JsonPropertyName("hospital")]
        public string? Hospital { get; set; }

        
    }
}

