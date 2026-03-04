using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeTraining.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeTraining.Commands
{
    public class GetSingleEmployeeTrainingCommand : IRequest<ApiResponse<EmployeeTrainingDto>>
    {
        [JsonPropertyName("empTrainingId")]
        public int EmpTrainingId { get; set; }

    }
}
