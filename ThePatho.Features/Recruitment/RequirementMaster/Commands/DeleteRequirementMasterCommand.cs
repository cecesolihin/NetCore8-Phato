using MediatR;

namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class DeleteRequirementMasterCommand : IRequest<bool>
    {
        public string QuestionCode { get; set; }
    }
}
