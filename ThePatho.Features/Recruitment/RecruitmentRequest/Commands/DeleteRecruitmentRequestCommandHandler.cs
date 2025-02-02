using MediatR;
using System;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitmentRequest.Service;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class DeleteRecruitmentRequestCommandHandler : IRequestHandler<DeleteRecruitmentRequestCommand, ApiResponse>
    {
        private readonly IRecruitmentRequestService recruitmentRequestService;

        public DeleteRecruitmentRequestCommandHandler(IRecruitmentRequestService _recruitmentRequestService)
        {
            recruitmentRequestService = _recruitmentRequestService;
        }

        public async Task<ApiResponse> Handle(DeleteRecruitmentRequestCommand request, CancellationToken cancellationToken)
        {
           
            return await recruitmentRequestService.DeleteRecruitmentRequest(request);
               
        }
    }
}
