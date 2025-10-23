using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeTraining.Commands
{
    public class SubmitEmployeeTrainingCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("emp_training_id")]
        public int EmpTrainingId { get; set; }

        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("training_course_code")]
        public string TrainingCourseCode { get; set; } = null!;

        [JsonPropertyName("start_date")]
        public string StartDate { get; set; } = null!;

        [JsonPropertyName("training_type_code")]
        public string TrainingTypeCode { get; set; } = null!;

        [JsonPropertyName("training_field_code")]
        public string TrainingFieldCode { get; set; } = null!;

        [JsonPropertyName("institution")]
        public string Institution { get; set; } = null!;

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("city_code")]
        public string CityCode { get; set; } = null!;

        [JsonPropertyName("certificate_no")]
        public string? CertificateNo { get; set; }

        [JsonPropertyName("certificate_date")]
        public string? CertificateDate { get; set; }

        [JsonPropertyName("end_date")]
        public string? EndDate { get; set; }

        [JsonPropertyName("training_payer_code")]
        public string TrainingPayerCode { get; set; } = null!;

        [JsonPropertyName("company_bond_date")]
        public string? CompanyBondDate { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("training_batch_code")]
        public string? TrainingBatchCode { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

