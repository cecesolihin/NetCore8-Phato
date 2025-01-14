using MediatR;
using System;
using ThePatho.Features.Recruitment.RecruitmentRequest.Service;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class DeleteRecruitmentRequestCommandHandler : IRequestHandler<DeleteRecruitmentRequestCommand, bool>
    {
        private readonly IRecruitmentRequestService recruitmentRequestService;

        public DeleteRecruitmentRequestCommandHandler(IRecruitmentRequestService _recruitmentRequestService)
        {
            recruitmentRequestService = _recruitmentRequestService;
        }

        public async Task<bool> Handle(DeleteRecruitmentRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await recruitmentRequestService.DeleteRecruitmentRequest(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }
}
