using MediatR;

using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class GetQuestionSettingCommandHandler : IRequestHandler<GetQuestionSettingCommand, QuestionSettingItemDto>
    {
        private readonly IQuestionSettingService questionSettingService;

        public GetQuestionSettingCommandHandler(IQuestionSettingService _questionSettingService)
        {
            questionSettingService = _questionSettingService;
        }

        public async Task<QuestionSettingItemDto> Handle(GetQuestionSettingCommand request, CancellationToken cancellationToken)
        {
            var data = await questionSettingService.GetQuestionSetting(request);

            return new QuestionSettingItemDto
            {
                DataOfRecords = data.Count,
                QuestionSettingList = data
            };
        }
    }
}
