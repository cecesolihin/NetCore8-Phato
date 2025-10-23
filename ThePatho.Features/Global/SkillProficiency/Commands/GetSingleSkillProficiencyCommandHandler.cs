using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.SkillProficiency.Service;
using ThePatho.Features.Global.SkillProficiency.DTO;

namespace ThePatho.Features.Global.SkillProficiency.Commands
{
    public class GetSingleSkillProficiencyCommandHandler : IRequestHandler<GetSingleSkillProficiencyCommand, ApiResponse<SkillProficiencyDto>>
    {
        private readonly ISkillProficiencyService Service;

        public GetSingleSkillProficiencyCommandHandler(ISkillProficiencyService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<SkillProficiencyDto>> Handle(GetSingleSkillProficiencyCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleSkillProficiency(request);
        }
    }
}
