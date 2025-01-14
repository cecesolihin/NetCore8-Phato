using MediatR;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class DeleteRecruitmentRequestCommand : IRequest<bool>
    {
        public string RequestNo { get; set; }
    }
}
