using MediatR;

namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class SubmitRequirementMasterCommand : IRequest<string>
    {
        public string QuestionCode { get; set; }
        public string QuestionName { get; set; }
        public string Action { get; set; }

    }

}
