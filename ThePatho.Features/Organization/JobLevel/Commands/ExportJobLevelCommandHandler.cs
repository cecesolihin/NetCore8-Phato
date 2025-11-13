using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevel.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class ExportJobLevelCommandHandler : IRequestHandler<ExportJobLevelCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IJobLevelService jobLevelService;

        public ExportJobLevelCommandHandler(IJobLevelService _jobLevelService)
        {
            jobLevelService = _jobLevelService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportJobLevelCommand request, CancellationToken cancellationToken)
        {
            return await jobLevelService.ExportJobLevelAsync(request.Type);
        }
    }
}