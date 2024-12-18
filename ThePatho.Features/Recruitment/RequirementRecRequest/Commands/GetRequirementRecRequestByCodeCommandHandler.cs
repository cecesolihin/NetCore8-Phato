using MediatR;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;
using ThePatho.Features.Recruitment.RequirementRecRequest.Service;

namespace ThePatho.Features.Recruitment.RequirementRecRequest.Commands
{
    public class GetRequirementRecRequestByCodeCommandHandler : IRequestHandler<GetRequirementRecRequestByCodeCommand, RequirementRecRequestItemDto>
    {
        private readonly IRequirementRecRequestService requirementRecRequestService;
        public GetRequirementRecRequestByCodeCommandHandler(IRequirementRecRequestService _requirementRecRequestService)
        {
            requirementRecRequestService = _requirementRecRequestService;
        }
        public async Task<RequirementRecRequestItemDto> Handle(GetRequirementRecRequestByCodeCommand request, CancellationToken cancellationToken)
        {
            var data = await requirementRecRequestService.GetRequirementRecRequestByCode(request);

            return new RequirementRecRequestItemDto
            {
                DataOfRecords = data.Count,
                RequirementRecRequestList = data,
            };
        }
    }
}
