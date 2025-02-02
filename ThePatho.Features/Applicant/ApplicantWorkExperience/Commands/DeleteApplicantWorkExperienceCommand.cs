using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class DeleteApplicantWorkExperienceCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("app_work_exp_id")]
        public int AppWorkExpId { get; set; }
    }
}
