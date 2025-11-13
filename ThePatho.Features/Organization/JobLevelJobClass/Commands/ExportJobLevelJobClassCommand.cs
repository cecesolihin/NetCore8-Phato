using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.JobLevelJobClass.Commands
{
    public class ExportJobLevelJobClassCommand : IRequest<ApiResponse<AttachmentFileDto>>
    {
        public string Type { get; set; }
    }
}