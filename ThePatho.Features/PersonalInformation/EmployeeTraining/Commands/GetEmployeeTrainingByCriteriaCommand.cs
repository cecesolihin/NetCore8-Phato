using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeTraining.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeTraining.Commands
{
    public class GetEmployeeTrainingByCriteriaCommand : IRequest<ApiResponse<EmployeeTrainingItemDto>>
    {
        [JsonPropertyName("filter_EmployeeId")]
        public int? FilterEmployeeId { get; set; }

        [JsonPropertyName("filter_TrainingCourseCode")]
        public string? FilterTrainingCourseCode { get; set; }

        [JsonPropertyName("filter_TrainingTypeCode")]
        public string? FilterTrainingTypeCode { get; set; }

        [JsonPropertyName("filter_TrainingFieldCode")]
        public string? FilterTrainingFieldCode { get; set; }
    }
}

