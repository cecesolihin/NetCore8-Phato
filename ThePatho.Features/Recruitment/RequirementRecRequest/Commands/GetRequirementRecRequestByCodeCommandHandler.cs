using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;
using ThePatho.Features.Recruitment.RequirementRecRequest.Service;

namespace ThePatho.Features.Recruitment.RequirementRecRequest.Commands
{
    public class GetRequirementRecRequestByCriteriaCommandHandler : IRequestHandler<GetRequirementRecRequestByCriteriaCommand, NewApiResponse<RequirementRecRequestItemDto>>
    {
        private readonly IRequirementRecRequestService requirementRecRequestService;
        public GetRequirementRecRequestByCriteriaCommandHandler(IRequirementRecRequestService _requirementRecRequestService)
        {
            requirementRecRequestService = _requirementRecRequestService;
        }
        public async Task<NewApiResponse<RequirementRecRequestItemDto>> Handle(GetRequirementRecRequestByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await requirementRecRequestService.GetRequirementRecRequestByCriteria(request);

        }
    }
}
