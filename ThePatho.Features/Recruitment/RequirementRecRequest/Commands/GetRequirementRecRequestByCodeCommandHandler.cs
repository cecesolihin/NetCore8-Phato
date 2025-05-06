using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;
using ThePatho.Features.Recruitment.RequirementRecRequest.Service;

namespace ThePatho.Features.Recruitment.RequirementRecRequest.Commands
{
    public class GetRequirementRecRequestByCriteriaCommandHandler : IRequestHandler<GetRequirementRecRequestByCriteriaCommand, ApiResponse<RequirementRecRequestItemDto>>
    {
        private readonly IRequirementRecRequestService requirementRecRequestService;
        public GetRequirementRecRequestByCriteriaCommandHandler(IRequirementRecRequestService _requirementRecRequestService)
        {
            requirementRecRequestService = _requirementRecRequestService;
        }
        public async Task<ApiResponse<RequirementRecRequestItemDto>> Handle(GetRequirementRecRequestByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await requirementRecRequestService.GetRequirementRecRequestByCriteria(request);

        }
    }
}
