using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Skill.Service;

namespace ThePatho.Features.Global.Skill.Commands
{
    public class SubmitSkillCommandHandler : IRequestHandler<SubmitSkillCommand, ApiResponse>
    {
        private readonly ISkillService skillService;

        public SubmitSkillCommandHandler(ISkillService _skillService)
        {
            skillService = _skillService;
        }

        public async Task<ApiResponse> Handle(SubmitSkillCommand request, CancellationToken cancellationToken)
        {
            return await skillService.SubmitSkill(request);
        }
    }
}
