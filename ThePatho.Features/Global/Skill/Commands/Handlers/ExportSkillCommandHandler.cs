using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.Skill.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Skill.Commands.Handlers
{
    public class ExportSkillCommandHandler : IRequestHandler<ExportSkillCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ISkillService _service;
        public ExportSkillCommandHandler(ISkillService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportSkillCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
