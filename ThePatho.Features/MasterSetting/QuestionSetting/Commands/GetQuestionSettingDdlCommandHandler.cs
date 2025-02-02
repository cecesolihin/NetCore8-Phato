using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class GetQuestionSettingDdlCommandHandler : IRequestHandler<GetQuestionSettingDdlCommand, NewApiResponse<QuestionSettingItemDto>>
    {
        private readonly IQuestionSettingService questionSettingService;

        public GetQuestionSettingDdlCommandHandler(IQuestionSettingService _QuestionSetting)
        {
            questionSettingService = _QuestionSetting;
        }

        public async Task<NewApiResponse<QuestionSettingItemDto>> Handle(GetQuestionSettingDdlCommand request, CancellationToken cancellationToken)
        {
            return await questionSettingService.GetQuestionSettingDdl(request);
        }
    }
}
