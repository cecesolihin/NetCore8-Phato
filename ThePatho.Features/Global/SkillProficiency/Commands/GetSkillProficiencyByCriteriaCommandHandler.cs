using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.SkillProficiency.Service;
using ThePatho.Features.Global.SkillProficiency.DTO;

namespace ThePatho.Features.Global.SkillProficiency.Commands
{
    public class GetSkillProficiencyByCriteriaCommandHandler : IRequestHandler<GetSkillProficiencyByCriteriaCommand, ApiResponse<SkillProficiencyItemDto>>
    {
        private readonly ISkillProficiencyService skillProficiencyService;

        public GetSkillProficiencyByCriteriaCommandHandler(ISkillProficiencyService _skillProficiencyService)
        {
            skillProficiencyService = _skillProficiencyService;
        }

        public async Task<ApiResponse<SkillProficiencyItemDto>> Handle(GetSkillProficiencyByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await skillProficiencyService.GetSkillProficiencyByCriteria(request);
        }
    }
}
