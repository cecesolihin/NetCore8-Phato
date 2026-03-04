using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Commands
{
    public class DeleteEmployeeMedicalCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("EmployeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("DiseaseCategoryCode")]
        public string DiseaseCategoryCode { get; set; } = null!;
    }
}

