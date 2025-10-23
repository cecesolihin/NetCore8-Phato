using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeMedical.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Commands
{
    public class GetEmployeeMedicalByCriteriaCommand : IRequest<ApiResponse<EmployeeMedicalItemDto>>
    {
        [JsonPropertyName("filter_employee_id")]
        public int? FilterEmployeeId { get; set; }

        [JsonPropertyName("filter_disease_name")]
        public string? FilterDiseaseName { get; set; }

        [JsonPropertyName("filter_hospital")]
        public string? FilterHospital { get; set; }

        
    }
}

