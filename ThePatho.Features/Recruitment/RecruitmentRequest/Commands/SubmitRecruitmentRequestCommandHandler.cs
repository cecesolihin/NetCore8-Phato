using MediatR;
using ThePatho.Features.Recruitment.RecruitmentRequest.Service;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class SubmitRecruitmentRequestCommandHandler : IRequestHandler<SubmitRecruitmentRequestCommand, string>
    {
        private readonly IRecruitmentRequestService recruitmentRequestService;

        public SubmitRecruitmentRequestCommandHandler(IRecruitmentRequestService _recruitmentRequestService)
        {
            recruitmentRequestService = _recruitmentRequestService;
        }

        public async Task<string> Handle(SubmitRecruitmentRequestCommand request, CancellationToken cancellationToken)
        {
            await recruitmentRequestService.SubmitRecruitmentRequest(request);
            if (request.Action == "ADD")
            {
                return "Recruitment Request successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Recruitment Request successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
