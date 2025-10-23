using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeMedical.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Commands
{
    public class GetSingleEmployeeMedicalCommand : IRequest<ApiResponse<EmployeeMedicalDto>>
    {
        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("disease_category_code")]
        public string DiseaseCategoryCode { get; set; } = null!;

    }
}
