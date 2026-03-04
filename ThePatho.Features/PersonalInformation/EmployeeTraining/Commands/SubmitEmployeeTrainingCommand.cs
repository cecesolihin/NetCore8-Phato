using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeTraining.Commands
{
    public class SubmitEmployeeTrainingCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("empTrainingId")]
        public int EmpTrainingId { get; set; }

        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("trainingCourseCode")]
        public string TrainingCourseCode { get; set; } = null!;

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; } = null!;

        [JsonPropertyName("trainingTypeCode")]
        public string TrainingTypeCode { get; set; } = null!;

        [JsonPropertyName("trainingFieldCode")]
        public string TrainingFieldCode { get; set; } = null!;

        [JsonPropertyName("institution")]
        public string Institution { get; set; } = null!;

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("cityCode")]
        public string CityCode { get; set; } = null!;

        [JsonPropertyName("certificateNo")]
        public string? CertificateNo { get; set; }

        [JsonPropertyName("certificateDate")]
        public string? CertificateDate { get; set; }

        [JsonPropertyName("endDate")]
        public string? EndDate { get; set; }

        [JsonPropertyName("trainingPayerCode")]
        public string TrainingPayerCode { get; set; } = null!;

        [JsonPropertyName("companyBondDate")]
        public string? CompanyBondDate { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("trainingBatchCode")]
        public string? TrainingBatchCode { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

