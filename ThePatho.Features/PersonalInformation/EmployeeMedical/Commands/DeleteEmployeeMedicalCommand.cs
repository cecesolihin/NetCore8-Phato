using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Commands
{
    public class DeleteEmployeeMedicalCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("disease_category_code")]
        public string DiseaseCategoryCode { get; set; } = null!;
    }
}

