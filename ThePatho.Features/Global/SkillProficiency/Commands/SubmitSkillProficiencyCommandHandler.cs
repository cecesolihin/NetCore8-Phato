using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.SkillProficiency.Service;

namespace ThePatho.Features.Global.SkillProficiency.Commands
{
    public class SubmitSkillProficiencyCommandHandler : IRequestHandler<SubmitSkillProficiencyCommand, ApiResponse>
    {
        private readonly ISkillProficiencyService skillProficiencyService;

        public SubmitSkillProficiencyCommandHandler(ISkillProficiencyService _skillProficiencyService)
        {
            skillProficiencyService = _skillProficiencyService;
        }

        public async Task<ApiResponse> Handle(SubmitSkillProficiencyCommand request, CancellationToken cancellationToken)
        {
            return await skillProficiencyService.SubmitSkillProficiency(request);
        }
    }
}
