using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.SkillProficiency.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.SkillProficiency.Commands.Handlers
{
    public class ExportSkillProficiencyCommandHandler : IRequestHandler<ExportSkillProficiencyCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ISkillProficiencyService _service;
        public ExportSkillProficiencyCommandHandler(ISkillProficiencyService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportSkillProficiencyCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
