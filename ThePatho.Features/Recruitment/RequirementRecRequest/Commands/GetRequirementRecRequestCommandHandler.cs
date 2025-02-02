using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;
using ThePatho.Features.Recruitment.RequirementRecRequest.Service;

namespace ThePatho.Features.Recruitment.RequirementRecRequest.Commands
{
    public class GetRequirementRecRequestCommandHandler : IRequestHandler<GetRequirementRecRequestCommand, NewApiResponse<RequirementRecRequestItemDto>>
    {
        private readonly IRequirementRecRequestService requirementRecRequestService;
        public GetRequirementRecRequestCommandHandler(IRequirementRecRequestService _requirementRecRequestService)
        {
            requirementRecRequestService =_requirementRecRequestService;
        }
        public async Task<NewApiResponse<RequirementRecRequestItemDto>> Handle(GetRequirementRecRequestCommand request, CancellationToken cancellationToken)
        {
            return await requirementRecRequestService.GetRequirementRecRequest(request);

        }
    }
}
