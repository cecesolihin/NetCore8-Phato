using MediatR;

using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class GetQuestionSettingCommandHandler : IRequestHandler<GetQuestionSettingCommand, QuestionSettingItemDto>
    {
        private readonly IQuestionSettingService QuestionSettingService;

        public GetQuestionSettingCommandHandler(IQuestionSettingService _QuestionSettingService)
        {
            QuestionSettingService = _QuestionSettingService;
        }

        public async Task<QuestionSettingItemDto> Handle(GetQuestionSettingCommand request, CancellationToken cancellationToken)
        {
            var questionSettings = await QuestionSettingService.GetQuestionSetting(request);

            return new QuestionSettingItemDto
            {
                DataOfRecords = questionSettings.Count,
                QuestionSettingList = questionSettings
            };
        }
    }
}
