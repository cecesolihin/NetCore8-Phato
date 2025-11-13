using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevelJobClass.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.JobLevelJobClass.Commands
{
    public class ExportJobLevelJobClassCommandHandler : IRequestHandler<ExportJobLevelJobClassCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IJobLevelJobClassService jobLevelJobClassService;

        public ExportJobLevelJobClassCommandHandler(IJobLevelJobClassService _jobLevelJobClassService)
        {
            jobLevelJobClassService = _jobLevelJobClassService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportJobLevelJobClassCommand request, CancellationToken cancellationToken)
        {
            return await jobLevelJobClassService.ExportJobLevelJobClassAsync(request.Type);
        }
    }
}