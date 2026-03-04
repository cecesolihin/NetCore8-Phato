using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeTraining.Commands
{
    public class DeleteEmployeeTrainingCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("empTrainingId")]
        public int EmpTrainingId { get; set; }
    }
}

