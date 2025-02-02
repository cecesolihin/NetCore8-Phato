using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class SubmitApplicationApplicantCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("rec_application_id")]
        public int RecApplicationId { get; set; }

        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }

        [JsonPropertyName("request_no")]
        public string RequestNo { get; set; }

        [JsonPropertyName("applied_date")]
        public DateTime? AppliedDate { get; set; }

        [JsonPropertyName("ads_code")]
        public string AdsCode { get; set; }

        [JsonPropertyName("recruitment_fee")]
        public string RecruitmentFee { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }

        [JsonPropertyName("moved_from")]
        public int? MovedFrom { get; set; }

        [JsonPropertyName("date_moved")]
        public DateTime? DateMoved { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("employee_id")]
        public int? EmployeeId { get; set; }

        [JsonPropertyName("internal_applicant")]
        public bool? InternalApplicant { get; set; }

        [JsonPropertyName("email_confirm")]
        public bool? EmailConfirm { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
