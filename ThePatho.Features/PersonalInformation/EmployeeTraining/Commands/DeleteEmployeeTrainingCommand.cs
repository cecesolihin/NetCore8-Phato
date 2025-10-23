using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeTraining.Commands
{
    public class DeleteEmployeeTrainingCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("emp_training_id")]
        public int EmpTrainingId { get; set; }
    }
}

