using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeTraining.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeTraining.Commands
{
    public class GetEmployeeTrainingByCriteriaCommand : IRequest<ApiResponse<EmployeeTrainingItemDto>>
    {
        [JsonPropertyName("employeeId")]
        public int? EmployeeId { get; set; }

        [JsonPropertyName("trainingCourseCode")]
        public string? TrainingCourseCode { get; set; }

        [JsonPropertyName("trainingTypeCode")]
        public string? TrainingTypeCode { get; set; }

        [JsonPropertyName("trainingFieldCode")]
        public string? TrainingFieldCode { get; set; }
    }
}

