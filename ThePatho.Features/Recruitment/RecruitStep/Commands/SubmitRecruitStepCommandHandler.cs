using MediatR;
using ThePatho.Features.Recruitment.RecruitStep.Service;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class SubmitRecruitStepCommandHandler : IRequestHandler<SubmitRecruitStepCommand, string>
    {
        private readonly IRecruitStepService recruitStepService;

        public SubmitRecruitStepCommandHandler(IRecruitStepService _recruitStepService)
        {
            recruitStepService = _recruitStepService;
        }

        public async Task<string> Handle(SubmitRecruitStepCommand request, CancellationToken cancellationToken)
        {
            await recruitStepService.SubmitRecruitStep(request);
            if (request.Action == "ADD")
            {
                return "Recruitment Step successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Recruitment Step successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
