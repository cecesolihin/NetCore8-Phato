using MediatR;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class SubmitQuestionSettingCommandHandler : IRequestHandler<SubmitQuestionSettingCommand, string>
    {
        private readonly IQuestionSettingService auestionSettingService;

        public SubmitQuestionSettingCommandHandler(IQuestionSettingService _questionSettingService)
        {
            auestionSettingService = _questionSettingService;
        }

        public async Task<string> Handle(SubmitQuestionSettingCommand request, CancellationToken cancellationToken)
        {
            await auestionSettingService.SubmitQuestionSetting(request);
            if (request.Action == "ADD")
            {
                return "Question Setting successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Question Setting successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
