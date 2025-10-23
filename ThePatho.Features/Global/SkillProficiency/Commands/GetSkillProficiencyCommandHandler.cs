using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.SkillProficiency.Service;
using ThePatho.Features.Global.SkillProficiency.DTO;

namespace ThePatho.Features.Global.SkillProficiency.Commands
{
    public class GetSkillProficiencyCommandHandler : IRequestHandler<GetSkillProficiencyCommand, ApiResponse<SkillProficiencyItemDto>>
    {
        private readonly ISkillProficiencyService skillProficiencyService;

        public GetSkillProficiencyCommandHandler(ISkillProficiencyService _skillProficiencyService)
        {
            skillProficiencyService = _skillProficiencyService;
        }

        public async Task<ApiResponse<SkillProficiencyItemDto>> Handle(GetSkillProficiencyCommand request, CancellationToken cancellationToken)
        {
            return await skillProficiencyService.GetSkillProficiency(request);
        }
    }
}
