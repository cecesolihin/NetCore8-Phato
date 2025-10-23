using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Skill.Service;
using ThePatho.Features.Global.Skill.DTO;

namespace ThePatho.Features.Global.Skill.Commands
{
    public class GetSkillCommandHandler : IRequestHandler<GetSkillCommand, ApiResponse<SkillItemDto>>
    {
        private readonly ISkillService skillService;

        public GetSkillCommandHandler(ISkillService _skillService)
        {
            skillService = _skillService;
        }

        public async Task<ApiResponse<SkillItemDto>> Handle(GetSkillCommand request, CancellationToken cancellationToken)
        {
            return await skillService.GetSkill(request);
        }
    }
}
