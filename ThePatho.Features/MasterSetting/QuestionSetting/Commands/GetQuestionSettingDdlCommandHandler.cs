using MediatR;
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class GetQuestionSettingDdlCommandHandler : IRequestHandler<GetQuestionSettingDdlCommand, QuestionSettingItemDto>
    {
        private readonly IQuestionSettingService questionSettingService;

        public GetQuestionSettingDdlCommandHandler(IQuestionSettingService _QuestionSetting)
        {
            questionSettingService = _QuestionSetting;
        }

        public async Task<QuestionSettingItemDto> Handle(GetQuestionSettingDdlCommand request, CancellationToken cancellationToken)
        {
            var data = await questionSettingService.GetQuestionSettingDdl(request);

            return new QuestionSettingItemDto
            {
                DataOfRecords = data.Count,
                QuestionSettingList = data
            };
        }
    }
}
