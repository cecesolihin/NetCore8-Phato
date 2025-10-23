using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Skill.Service;
using ThePatho.Features.Global.Skill.DTO;

namespace ThePatho.Features.Global.Skill.Commands
{
    public class GetSingleSkillCommandHandler : IRequestHandler<GetSingleSkillCommand, ApiResponse<SkillDto>>
    {
        private readonly ISkillService Service;

        public GetSingleSkillCommandHandler(ISkillService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<SkillDto>> Handle(GetSingleSkillCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleSkill(request);
        }
    }
}
