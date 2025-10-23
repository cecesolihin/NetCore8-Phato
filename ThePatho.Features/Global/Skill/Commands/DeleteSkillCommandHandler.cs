using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Skill.Service;

namespace ThePatho.Features.Global.Skill.Commands
{
    public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, ApiResponse>
    {
        private readonly ISkillService skillService;

        public DeleteSkillCommandHandler(ISkillService _skillService)
        {
            skillService = _skillService;
        }

        public async Task<ApiResponse> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            return await skillService.DeleteSkill(request);
        }
    }
}
