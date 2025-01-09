using MediatR;
namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class DeleteApplicantEducationCommand : IRequest<bool>
    {
        public string ApplicantNo { get; set; }
        public string EduLevelCode { get; set; }
        public string MajorCode { get; set; }
    }
}
