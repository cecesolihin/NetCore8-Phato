using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class SubmitQuestionSettingCommandHandler : IRequestHandler<SubmitQuestionSettingCommand, ApiResponse>
    {
        private readonly IQuestionSettingService auestionSettingService;

        public SubmitQuestionSettingCommandHandler(IQuestionSettingService _questionSettingService)
        {
            auestionSettingService = _questionSettingService;
        }

        public async Task<ApiResponse> Handle(SubmitQuestionSettingCommand request, CancellationToken cancellationToken)
        {
            return await auestionSettingService.SubmitQuestionSetting(request);
        }
    }
}
