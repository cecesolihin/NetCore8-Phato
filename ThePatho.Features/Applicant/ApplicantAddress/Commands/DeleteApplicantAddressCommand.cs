using MediatR;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class DeleteApplicantAddressCommand : IRequest<bool>
    {
        public string ApplicantNo { get; set; } 
    }
}
