using MediatR;
using ThePatho.Features.Recruitment.RecruitStepGroup.Service;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class SubmitRecruitStepGroupCommandHandler : IRequestHandler<SubmitRecruitStepGroupCommand, string>
    {
        private readonly IRecruitStepGroupService recruitStepGroupService;

        public SubmitRecruitStepGroupCommandHandler(IRecruitStepGroupService _recruitStepGroupService)
        {
            recruitStepGroupService = _recruitStepGroupService;
        }

        public async Task<string> Handle(SubmitRecruitStepGroupCommand request, CancellationToken cancellationToken)
        {
            await recruitStepGroupService.SubmitRecruitStepGroup(request);
            if (request.Action == "ADD")
            {
                return "Requirement Step Group successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Requirement Step Group successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
