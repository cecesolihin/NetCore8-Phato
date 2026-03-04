using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeFamily.Commands
{
    public class DeleteEmployeeFamilyCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("EmployeeFamilyId")]
        public int EmployeeFamilyId { get; set; }
    }
}

