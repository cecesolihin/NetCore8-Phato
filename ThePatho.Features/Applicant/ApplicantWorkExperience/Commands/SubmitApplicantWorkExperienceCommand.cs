using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class SubmitApplicantWorkExperienceCommand : IRequest<string>
    {
        [JsonPropertyName("app_work_exp_id")]
        public int AppWorkExpId { get; set; }

        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }

        [JsonPropertyName("start_working")]
        public DateTime StartWorking { get; set; }

        [JsonPropertyName("end_working")]
        public DateTime? EndWorking { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("business_field")]
        public string BusinessField { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("city_code")]
        public string CityCode { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("resign_reason_code")]
        public string ResignReasonCode { get; set; }

        [JsonPropertyName("emp_type_code")]
        public string EmpTypeCode { get; set; }

        [JsonPropertyName("organization")]
        public string Organization { get; set; }

        [JsonPropertyName("job_level")]
        public string JobLevel { get; set; }

        [JsonPropertyName("job_desc")]
        public string JobDesc { get; set; }

        [JsonPropertyName("reference_name")]
        public string ReferenceName { get; set; }

        [JsonPropertyName("reference_phone")]
        public string ReferencePhone { get; set; }

        [JsonPropertyName("reference_email")]
        public string ReferenceEmail { get; set; }

        [JsonPropertyName("remark")]
        public string Remark { get; set; }

        [JsonPropertyName("is_last_work_experience")]
        public bool IsLastWorkExperience { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
