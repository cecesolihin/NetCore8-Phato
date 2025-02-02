using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class GetQuestionSettingCommandHandler : IRequestHandler<GetQuestionSettingCommand, NewApiResponse<QuestionSettingItemDto>>
    {
        private readonly IQuestionSettingService questionSettingService;

        public GetQuestionSettingCommandHandler(IQuestionSettingService _questionSettingService)
        {
            questionSettingService = _questionSettingService;
        }

        public async Task<NewApiResponse<QuestionSettingItemDto>> Handle(GetQuestionSettingCommand request, CancellationToken cancellationToken)
        {
            return await questionSettingService.GetQuestionSetting(request);
        }
    }
}
