using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.SkillProficiency.Service;

namespace ThePatho.Features.Global.SkillProficiency.Commands
{
    public class DeleteSkillProficiencyCommandHandler : IRequestHandler<DeleteSkillProficiencyCommand, ApiResponse>
    {
        private readonly ISkillProficiencyService skillProficiencyService;

        public DeleteSkillProficiencyCommandHandler(ISkillProficiencyService _skillProficiencyService)
        {
            skillProficiencyService = _skillProficiencyService;
        }

        public async Task<ApiResponse> Handle(DeleteSkillProficiencyCommand request, CancellationToken cancellationToken)
        {
            return await skillProficiencyService.DeleteSkillProficiency(request);
        }
    }
}
