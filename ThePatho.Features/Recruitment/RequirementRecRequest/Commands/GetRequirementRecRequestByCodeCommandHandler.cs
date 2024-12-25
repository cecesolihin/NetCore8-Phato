using MediatR;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;
using ThePatho.Features.Recruitment.RequirementRecRequest.Service;

namespace ThePatho.Features.Recruitment.RequirementRecRequest.Commands
{
    public class GetRequirementRecRequestByCriteriaCommandHandler : IRequestHandler<GetRequirementRecRequestByCriteriaCommand, RequirementRecRequestItemDto>
    {
        private readonly IRequirementRecRequestService requirementRecRequestService;
        public GetRequirementRecRequestByCriteriaCommandHandler(IRequirementRecRequestService _requirementRecRequestService)
        {
            requirementRecRequestService = _requirementRecRequestService;
        }
        public async Task<RequirementRecRequestItemDto> Handle(GetRequirementRecRequestByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await requirementRecRequestService.GetRequirementRecRequestByCriteria(request);

            return new RequirementRecRequestItemDto
            {
                DataOfRecords = data.Count,
                RequirementRecRequestList = data,
            };
        }
    }
}
