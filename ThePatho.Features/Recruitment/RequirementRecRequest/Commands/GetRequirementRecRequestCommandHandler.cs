using MediatR;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;
using ThePatho.Features.Recruitment.RequirementRecRequest.Service;

namespace ThePatho.Features.Recruitment.RequirementRecRequest.Commands
{
    public class GetRequirementRecRequestCommandHandler : IRequestHandler<GetRequirementRecRequestCommand, RequirementRecRequestItemDto>
    {
        private readonly IRequirementRecRequestService requirementRecRequestService;
        public GetRequirementRecRequestCommandHandler(IRequirementRecRequestService _requirementRecRequestService)
        {
            requirementRecRequestService =_requirementRecRequestService;
        }
        public async Task<RequirementRecRequestItemDto> Handle(GetRequirementRecRequestCommand request, CancellationToken cancellationToken)
        {
            var data = await requirementRecRequestService.GetRequirementRecRequest(request);

            return new RequirementRecRequestItemDto
            {
                DataOfRecords = data.Count,
                RequirementRecRequestList = data,
            };
        }
    }
}
