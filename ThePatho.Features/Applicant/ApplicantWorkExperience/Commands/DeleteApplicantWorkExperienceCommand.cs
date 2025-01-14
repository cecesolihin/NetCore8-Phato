using MediatR;
using System.Text.Json.Serialization;
namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class DeleteApplicantWorkExperienceCommand : IRequest<bool>
    {
        [JsonPropertyName("app_work_exp_id")]
        public int AppWorkExpId { get; set; }
    }
}
