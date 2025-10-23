using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Skill.Service;
using ThePatho.Features.Global.Skill.DTO;

namespace ThePatho.Features.Global.Skill.Commands
{
    public class GetSkillByCriteriaCommandHandler : IRequestHandler<GetSkillByCriteriaCommand, ApiResponse<SkillItemDto>>
    {
        private readonly ISkillService skillService;

        public GetSkillByCriteriaCommandHandler(ISkillService _skillService)
        {
            skillService = _skillService;
        }

        public async Task<ApiResponse<SkillItemDto>> Handle(GetSkillByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await skillService.GetSkillByCriteria(request);
        }
    }
}
