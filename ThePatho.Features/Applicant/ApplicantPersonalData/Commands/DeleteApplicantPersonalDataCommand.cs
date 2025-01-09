using MediatR;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class DeleteApplicantPersonalDataCommand : IRequest<bool>
    {
        public string ApplicantNo { get; set; } 
    }
}
